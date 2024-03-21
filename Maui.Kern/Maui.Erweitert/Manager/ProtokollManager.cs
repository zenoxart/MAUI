using Maui.Kern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Erweitert.Manager
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten
    /// des Anwendungsprotokolls bereit
    /// </summary>
    /// <remarks>
    /// In MAUI - Anwendungen wird für die Threadsicherheit garantiert,
    /// wenn die Dispatcher Eigenschaft auf den 
    /// Anwendungsdispatcher festgelegt wird.
    /// Sonst ist die Threadsicherheit nicht
    /// gewährleistet.</remarks>
    public class ProtokollManager : ViewModelAppObjekt
	{
		/// <summary>
		/// Definiert die Anzahl an Versuchen
		/// </summary>
		private int VersuchAnzahl = 10;

		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private Daten.ProtokollEinträge? _Einträge = null;

		/// <summary>
		/// Ruft die Liste mit den Einträgen ab
		/// </summary>
		public Daten.ProtokollEinträge Einträge
		{
			get
			{
				this._Einträge ??= [];

				return this._Einträge;
			}
			protected set
			{
				if (this._Einträge != value)
				{
					this._Einträge = value;
					this.OnPropertyChanged();
				}
			}
		}

		/// <summary>
		/// Fügt dem Protokoll einen neuen Eintrag hinzu
		/// </summary>
		/// <param name="eintrag">Protokolleintrag, der
		/// am Ende angehängt werden soll</param>
		/// <remarks>Für die Threadsicherheit wird für MAUI garantiert, 
		/// wenn ein Dispatcher vorhanden ist, sonst ist die 
		/// Threadsicherheit nicht gewährleistet.</remarks>
		public virtual void Eintragen(Daten.ProtokollEintrag eintrag)
		{
			// Prüfe für die Threadsicherheit ,
			// ob ein Dispatcher vorhanden ist
			if (Dispatcher != null)
			{
				Invoke();
			}
			else
			{
				// Keine Threadsicherheit
				// Weil kein Dispatcher eingestellt ist
				Eintragen();
			}

			// Interne Hilfsmethode zum Aktivieren der Methode aus der Reflection
			void Invoke()
			{
				// Die Beschreibung der InvokeAsync Methode holen
				// Generisches Laden eines  Typen und von dem dann eine MethodInfo generiert wird
				System.Reflection.MethodInfo? InvokeMethode = Dispatcher?.GetType()?
					.GetMethod(
					"InvokeAsync",
					[typeof(System.Action)])
					;

				// die Methode ausführen,
				// d.h. den Dispatcher bitten,
				// den EIntrag threadsicher zu veranlassen
				if (InvokeMethode == null)
					// Keine Threadsicherheit
					// Weil das Objekt in der Dispatcher Eigenschaft
					// kein InvokeAsync hat
					Eintragen();
				else
					InvokeMethode.Invoke(
					obj: this.Dispatcher,
					parameters: [
						new System.Action(() => Eintragen())
					]);
			}


			// Interne Hilfsmethode zum Eintragen
			void Eintragen()
			{

				this.EintragSpeichern(eintrag);

				this.Einträge.Add(eintrag);



				// Falls ein Fehler eingetragen wurde,
				// EnthältFehler einschalten
				if (eintrag.Typ == Daten.ProtokollEintragTyp.Fehler)
				{
					this.EnthältFehler = true;
				}

				// Eventuell vorhandene Rückrufe ausführen
				// (hier wird auf das Feld geprüft, damit
				// die Liste nciht irrtümlch erstellt wird)
				if (this._Rückrufe != null)
				{
					// BETA, mit eventuel auftretenden null Verweisen rechnen

					int LebendeRückrufe = 0;
					foreach (var r in this.Rückrufe)
					{

						r.Methode?.Invoke();
						LebendeRückrufe++;
					}

					// 20210307 die if-Abfrage war falsch
					if (LebendeRückrufe > 0)
					{
						this._Einträge?.Add(
							new Daten.ProtokollEintrag
							{
								Typ = Daten.ProtokollEintragTyp.Fehler,
								Text = $"ERROR! {nameof(ProtokollManager)} has a callback without reciever.\r" +
                                       "Be sure to cancel booked callbacks if these are no longer needed!"
							});
					}
				}
			}
		}

		/// <summary>
		/// Fügt dem Protokoll einen normalen Eintrag hinzu
		/// </summary>
		/// <param name="text">Information, die als normaler
		/// Protokolleintrag am Ende angehängt werden soll</param>
		public virtual void Eintragen(string text)
		{
			this.Eintragen(
				new Daten.ProtokollEintrag
				{
					Typ = Daten.ProtokollEintragTyp.Normal,
					Text = text
				}
				);
		}

		/// <summary>
		/// Fügt dem Protokoll einen gewünschten Eintrag hinzu
		/// </summary>
		/// <param name="text">Information, die als 
		/// Protokolleintrag am Ende angehängt werden soll</param>
		/// <param name="typ">Die Art vom Eintrag</param>
		public virtual void Eintragen(string text, Daten.ProtokollEintragTyp typ)
		{
			this.Eintragen(
				new Daten.ProtokollEintrag
				{
					Typ = typ,
					Text = text
				}
				);
		}

		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private bool _EnthältFehler;

		/// <summary>
		/// Ruft einen Wahrheitwert ab oder legt diesen fest,
		/// der angibt ob Fehlereinträge im Protokoll sind
		/// </summary>
		public bool EnthältFehler
		{
			get
			{
				return this._EnthältFehler;
			}
			protected set
			{

				if (this._EnthältFehler != value)
				{
					this._EnthältFehler = value;
					if (this._EnthältFehler)
					{
						this.EnthältFehlerBlinkenAsync();
					}
					OnPropertyChanged();
				}
			}
		}

		/// <summary>
		/// Ruft den Verweis auf den MAUI Threadverteiler
		/// ab oder legt diesen fest
		/// </summary>
		/// <remarks>
		/// Falls ein Dispatcher eingestellt wird,
		/// ist das Eintragen von Protokolleinträgen
		/// für MAUI threadsicher</remarks>
		public object? Dispatcher { get; set; }

		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private Daten.SchwacherMethodenVerweisListe? _Rückrufe = null;

		/// <summary>
		/// Ruft die Liste mit den Methoden ab,
		/// die der ProtokollManager ausführen soll,
		/// wenn ein neuer Eintrag erstellt wurde
		/// </summary>
		public Daten.SchwacherMethodenVerweisListe Rückrufe
		{
			get
			{
				if (this._Rückrufe == null)
				{
					this._Rückrufe = [];
					this.Eintragen(
						$"{this} created a List for Callbacks!",
						Daten.ProtokollEintragTyp.Warnung);
				}

				return this._Rückrufe;
			}

		}


		/// <summary>
		/// Hinterlegt die gewünschte Rückrufmethode und 
		/// ruft diese auf, wenn ein neuer Protokolleintrag erstellt wird
		/// </summary>
		/// <param name="rückrufMethode">Verweis auf die Methode,
		/// die aufgerufen werden soll, wenn ein neuer
		/// Protokolleintrag erstllt wurde </param>
		/// <remarks>
		/// Die Methode wird als WeakReference 
		/// hinterlegtm danut der Garbage Collector
		/// nicht am Entfernen vom Abonnenten gehindert wird</remarks>
		public virtual void RückrufBuchen(System.Action rückrufMethode)
		{
			this.Rückrufe.Add(new Daten.SchwacherMethodenVerweis(rückrufMethode));

			this.Eintragen(
				$"{this} booked a callback method for {rückrufMethode.Target} (ID={rückrufMethode.Target?.GetHashCode()}).",
				Daten.ProtokollEintragTyp.Warnung);

			this.EnthältFehlerBlinkenAsync();
		}

		/// <summary>
		/// Storniert die gewünschte Rückrufmethode
		/// </summary>
		/// <param name="rückrufMethode">Verweis auf die Methode,
		/// die storniert werden soll</param>
		public virtual void RückrufStornieren(System.Action rückrufMethode)
		{
			if (this.Rückrufe.RemoveAll(rr => rr.Methode == rückrufMethode) > 0)
			{

				this.Eintragen(
					 $"{this} canceled a callback method for  {rückrufMethode.Target} (ID={rückrufMethode.Target?.GetHashCode()}).",
					 Daten.ProtokollEintragTyp.Warnung);
			}

		}

		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private bool _EnthältFehlerBlinken = false;

		/// <summary>
		/// Ruft ab true (800ms) und false (200ms),
		/// wenn HatFehler true ist
		/// </summary>
		public bool EnthältFehlerBlinken
		{
			get { return this._EnthältFehlerBlinken; }
			protected set
			{
				if (this._EnthältFehlerBlinken != value)
				{
					this._EnthältFehlerBlinken = value;
					OnPropertyChanged();
				}
			}
		}

		/// <summary>
		/// Internes Feld für den Status der Blinkenden LED
		/// </summary>
		private bool EnthältFehlerBlinkenLäuft { get; set; }

		/// <summary>
		/// Schaltet die Eigenschaft EnthältFehlerBlinkend
		/// 800 ms auf True und 200 ms auf False,
		/// wenn im Protokoll Fehlereinträge vorhanden sind
		/// </summary>
		protected virtual async void EnthältFehlerBlinkenAsync()
		{

			if (!this.EnthältFehlerBlinkenLäuft)
			{
				this.StartProtokollieren();
				this.EnthältFehlerBlinken = true;

				await System.Threading.Tasks.Task.Run(
					() =>
					{
						while (this.EnthältFehler)
						{
							this.EnthältFehlerBlinken = !this.EnthältFehlerBlinken;

							if (this.EnthältFehlerBlinken)
							{
								System.Threading.Thread.Sleep(800);
							}
							else
							{
								System.Threading.Thread.Sleep(200);
							}
						}
					});

				//Falls EnthältFehler zurückgesetzt wurde,
				//auf alle Fälle HatFehlerBlinkend 
				//ebenfalls abschalten
				this.EnthältFehlerBlinken = false;

				this.EnthältFehlerBlinkenLäuft = false;

				this.EndeProtokollieren();
			}
		}


		/// <summary>
		/// Internes Feld für das Setzten des Komprimierungsintervals
		/// </summary>
		private const int Zählzeit = 60000;

		/// <summary>
		/// Starten einen Zähler, welches im Inveral von n Minuten die funktion Komprimieren auslöst
		/// </summary>
		private void StarteZähler()
		{
			var zähler = new System.Timers.Timer(Zählzeit)
			{
				AutoReset = true
			};
			zähler.Elapsed += Komprimieren;

			zähler.Enabled = true;
		}

		/// <summary>
		/// Versucht die Protokolleinträge zu komprimieren
		/// </summary>
		protected void Komprimieren(object? sender, System.Timers.ElapsedEventArgs e)
		{
			Komprimierungsversuch();        // Hier wird die Asyncrone Komprimierung angekickt

			// Interne Methode zur Fehlerbehandlung des asyncronen Komprimieren, falls es auftritt
			void Komprimierungsversuch()
			{
				try
				{

					this.KomrpimierenAsync();


				}
				catch (Exception ex)
				{
					Eintragen(
						$"While compressing the Entries at {this.GetType().FullName} an ERROR occured." +
						$"Message= {ex.Message}",
						Daten.ProtokollEintragTyp.Fehler);
				}
			}
		}

		/// <summary>
		/// Entfernt die ProtokollEinträge welche älter als die Zählzeit 
		/// sind aus den Einträgen mit Ausnahme der Fehlermeldungen
		/// </summary>
		protected virtual async void KomrpimierenAsync()
		{
			await System.Threading.Tasks.Task.Run(
				() =>
				{

					if (this.Dispatcher != null)
					{


						var InvokeAsyncMethode = this.Dispatcher.GetType().GetMethod("InvokeAsync", [typeof(System.Action)]);

						if (InvokeAsyncMethode != null)
						{
							InvokeAsyncMethode.Invoke(
								this.Dispatcher,
                                [
									new System.Action(() => Komprimieren() )
								]);
						}
						else
						{
							Komprimieren();
						}

					}
					else
					{
						Komprimieren();
					}





					void Komprimieren()
					{

						var AlterZeitstempel = DateTimeOffset.Now.LocalDateTime.Subtract(new TimeSpan(0, 0, Zählzeit / 1000));
						int AnzahlEntfernteEinträge = 0;

						// Weil die ObservableCollection nur einen Eintrag
						// Eintrag entfernen kann, in einer Schleife die
						// Einträge prüfen...
						int i = 0;

						while (i < this.Einträge.Count)
						{
							if (this.Einträge[i].Typ != Daten.ProtokollEintragTyp.Fehler
								&& this.Einträge[i].Zeitstempel < AlterZeitstempel)
							{
								this.Einträge.RemoveAt(i);
								AnzahlEntfernteEinträge++;

								// Dadurch ist jetzt die Liste um
								// ein Element kürzer und das aktuelle "i"
								// zeigt bereits auf den nächsten Eintrag
							}
							else
							{
								// den nächsten Eintrag ansehen
								i++;
							}
						}

						// Einen "Lebenszeichen" Eintrag erstellen
						this.Eintragen(
							$"{this} has compressed the protocol at {System.DateTime.Now.ToShortTimeString()}." +
							$"{AnzahlEntfernteEinträge} {(AnzahlEntfernteEinträge == 1 ? "Entry" : "Entries have been")} removed.");

					}
				});
		}


		/// <summary>
		/// Ob das Protokoll 
		/// im Interval Komprimiert wird, 
		/// oder setzt dieses
		/// </summary>
		public void SetAutomatischKomprimieren(bool value)
		{
			if (value)
			{
				StarteZähler();
			}
		}

		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private string _Pfad = string.Empty;

		/// <summary>
		/// Ruft den Pfad für die APS.NET Konfiguration ab,
		/// oder legt diese fest
		/// </summary>
		/// <remarks> Wird die Eigenschaft leer gelassen, wird kein Protokoll geschrieben</remarks>
		public string Pfad
		{
			get
			{
				return this._Pfad;
			}
			set
			{

				this._Pfad = value;

				if (this._Pfad != string.Empty)
				{
					this.Eintragen($"Protocol-entries are located at \"{this._Pfad}\".");
				}
			}
		}

		/// <summary>
		/// Speichert die Daten des Protokolleintrags
		/// in der im Pfad angegebenen Datei
		/// </summary>
		/// <param name="eintrag">der in die .Log-Datei zu speichernde 
		/// Protokolleintrag</param>
		/// <remarks>Sollte beim Schreiben ein Fehler auftreten, 
		/// wird gewartet und wieder probiert und max. 10 mal wieder probiert,
		/// sollte das Problem nicht lösen, wird der Pfad entfernt 
		/// und damit das Speichern automatisch deaktiviert
		/// Fehler können auftreten, wenn meherere Zugriffe gleichzeitig sind und die Datei gesperrt ist</remarks>

		protected virtual void EintragSpeichern(Daten.ProtokollEintrag eintrag)
		{
			if (!string.IsNullOrEmpty(this.Pfad))
			{

				do
				{
					VersuchAnzahl = 10;

					try
					{
						using (var Schreiber = new System.IO.StreamWriter(
							this.Pfad,
							append: true
							))
						{

							const string Ausgabemuster = "{0}\t{1}\t{2}";

							Schreiber.WriteLine(
								string.Format(
									Ausgabemuster,
									eintrag.Zeitstempel.ToString(), 
									eintrag.Typ.ToString(), 
									eintrag.Text.Replace("\t", " ") // keine Tabulatoren in den Daten
												.Replace("\r", " ") // keine Eingabetaste in den Daten
												.Replace("\n", " ") // keinen Zeilenvorschub
									));
						}

						// Alles durchgelaufen
						VersuchAnzahl = 0;
					}
					catch (System.IO.IOException ioex)
					{
						// Es kann sein, das die Datei
						// aktuell von einem anderen Thread
						// gesperrt ist

						System.Threading.Thread.Sleep(100);
						this.OnFehlerAufgetreten(new FehlerAufgetretenEventArgs(ioex));

						VersuchAnzahl--;
					}
					catch (System.Exception ex)
					{
						this.OnFehlerAufgetreten(new FehlerAufgetretenEventArgs(ex));
						this.Pfad = string.Empty;
						VersuchAnzahl = 0;
					}
				} while (VersuchAnzahl > 0);
			}
		}

	}
}
