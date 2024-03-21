using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Kern.Manager
{
	/// <summary>
	/// Stellt einen Dienst zum Verwalten
	/// der Anwendungsfenster bereit
	/// </summary>
	public partial class FensterManager : AppObjekt
	{

		// 20210204 Der FensterManager speichert auch
		//          die Anzahl der Bildschirme bei einer
		//          Fensterposition, damit ein Fenster
		//          bei fehlendem Bildschirm nicht
		//          am falschen geöffnet werden
		//
		//          Auch die Auflösung mitspeichern
		//                und beim Wiederherstellen prüfen

		/// <summary>
		/// Liefert die Anzahl der Bildschirme
		/// im Rahmen von GetSystemMetrics
		/// </summary>
		private const int SM_CMONITORS = 80;

		/// <summary>
		/// Gibt spezifische Systeminformationen zurück
		/// </summary>
		/// <param name="info">Code der benötigten Information</param>
		[System.Runtime.InteropServices.LibraryImport("User32.dll", EntryPoint = "GetSystemMetricsA")]
		internal static partial int GetSystemMetrics(int info);

		/// <summary>
		/// Stellt einen Wrapper üfr die System-Matrix
		/// </summary>
		public static int GetSystemMetricsWrapper(int info)
		{
			if (info != 0)
			{
				return GetSystemMetrics(info);
			}
			return 0;
		}

		/// <summary>
		/// Ruft ein Schlüsseltext ab, der
		/// die Anzahl der aktuellen Bildschirme enthält
		/// </summary>
		/// <remarks>Die Info ist nicht gecachet,
		/// weil sich die Anzahl der Monitore
		/// dynamsich ändern kann</remarks>
		protected static string MonitorSchlüssel
		{
			get
			{
				// NICHT CACHEN!!!
				return $"_M{FensterManager.GetSystemMetricsWrapper(SM_CMONITORS)}";

			}
		}

		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private Daten.Fensterliste? _Liste = null;

		/// <summary>
		/// Ruft die verwalteten Fenster ab
		/// </summary>
		/// <remarks>Die Liste wird mit den
		/// Daten der im Xml-Format gespeicherten
		/// Fensterliste intialisiert</remarks>
		protected Daten.Fensterliste? Liste
		{
			get
			{
				this._Liste ??= this.Lesen();

				return this._Liste;
			}
		}

		/// <summary>
		/// Fügt dem Fenstermanager ein Fenster hinzu
		/// </summary>
		/// <param name="fenster">Objekt mit der Fensterposition</param>
		public void Hinterlegen(Daten.Fenster fenster)
		{

			// 20210204 Um mit mehreren Bildschirmen besser 
			//          umgehen zu können, zusätzlich die
			//          Anzahl der Monitore berücksichtigen

/* Nicht gemergte Änderung aus Projekt "Maui.Kern (net8.0-ios)"
Vor:
			fenster.Name += this.MonitorSchlüssel;
Nach:
			fenster.Name += MonitorSchlüssel;
*/
			fenster.Name += FensterManager.MonitorSchlüssel;
			//---

			// Prüfen, ob das Fenster bereits vorhanden ist
			var f = this.Liste?.Suchen(fenster.Name);

			// Falls nicht, das Fenster hinterlegen
			if (f == null)
			{
				this.Liste?.Add(fenster);
			}
			else
			{
				// sonst den Zustand und
				// die Positionsdaten aktualisieren

				// Weil Fenster ein Verweistyp ist,
				// wird hier direkt mit dem Objekt
				// in der Liste gearbeitet

				f.Zustand = fenster.Zustand;

				// Neue Positionsdaten aber nur
				// übernehmen, wenn welche vorhanden sind
				// Fad: eine herkömmliche Binärentscheidung
				if (fenster.Links != null)
				{
					f.Links = fenster.Links;
				}

				// Besser: eine Binärentscheidung in
				//         einer Anweisung mit ? :
				//         Entspricht der WENN() Funktion in Excel
				f.Oben = fenster.Oben != null ? fenster.Oben : f.Oben;

				// Noch schöner: Der NULL Überprüfungsoperator ??
				f.Breite = fenster.Breite ?? f.Breite;
				f.Höhe = fenster.Höhe ?? f.Höhe;
			}
		}

		/// <summary>
		/// Gibt das Objekt mit der Fensterposition zurück
		/// </summary>
		/// <param name="fensterName">Bezeichnung vom Fenster,
		/// dessen Positionsdaten benötigt werden</param>
		/// <returns>Null, falls das Fenster nicht gefunden wurde</returns>
		public Daten.Fenster? Abrufen(string fensterName)
		{
			// 20210204 Um mit mehreren Bildschirmen besser 
			//          umgehen zu können, zusätzlich die
			//          Anzahl der Monitore berücksichtigen


/* Nicht gemergte Änderung aus Projekt "Maui.Kern (net8.0-ios)"
Vor:
			return this.Liste?.Suchen(fensterName + this.MonitorSchlüssel);
Nach:
			return this.Liste?.Suchen(fensterName + MonitorSchlüssel);
*/
			return this.Liste?.Suchen(fensterName + FensterManager.MonitorSchlüssel);
		}

		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		/// <remarks>Statisch, weil sich der Benutzer
		/// während der Laufzeit nicht ändern kann</remarks>
		private static string? _StandardPfad = null;


		/// <summary>
		/// Legt den Standard Dateipfad fest
		/// </summary>
		private static void SetStandardPfad(string? value) 
			=> _StandardPfad = value;

		/// <summary>
		/// Gibt den Standard Dateipfad zurück
		/// </summary>

		private static string? GetStandardPfad() 
			=> _StandardPfad;

		/// <summary>
		/// Ruft das Verzeichnis ab, in dem
		/// die Fensterliste standardmäßig gespeichert wird.
		/// </summary>
		/// <remarks>Im AppData\Local der Anwendung</remarks>
		public string? StandardPfad
		{
			get
			{
				if (FensterManager.GetStandardPfad() == null)
				{
					SetStandardPfad(System.IO.Path.Combine(
							this.AppKontext?.LokalerDatenpfad ?? string.Empty,
							"Fenster.xml"));
				}

				return FensterManager.GetStandardPfad();
			}
		}

		/// <summary>
		/// Schreibt die Fensterliste als
		/// Xml-Datei im Anwendungsdaten-Verzeichnis
		/// </summary>
		/// <remarks>Sollte das Speichern nicht möglich sein,
		/// wird FehlerAufgetreten mit der Ursache ausgelöst</remarks>
		public void Speichern()
		{
			try
			{
				if (this.Liste != null && this.StandardPfad != null)
				{
					this.Controller?.Speichern(this.Liste, this.StandardPfad);
				}
			}
			catch (System.Exception ex)
			{
				this.OnFehlerAufgetreten(new FehlerAufgetretenEventArgs(ex));
			}
		}

		/// <summary>
		/// Holt aus dem Anwendungsdaten-Verzeichnis
		/// eine früher im Xml-Format gespeicherte
		/// Fensterliste und gibt diese zurück
		/// </summary>
		protected Maui.Kern.Daten.Fensterliste? Lesen()
		{
			try
			{
				return this.Controller?.Laden(this.StandardPfad ?? string.Empty);
			}
			catch (System.Exception ex)
			{
				// Passiert bei einem neuen Benutzer
				// In diesem Fall den Fehler ignorieren

				var VerbesserteAusnahme = new System.Exception(
					"Kann bei einem neuen Benutzer ignoriert werden!", ex);

				this.OnFehlerAufgetreten(new FehlerAufgetretenEventArgs(VerbesserteAusnahme));

				// Damit nicht null zurückgegeben wird
				return [];
			}
		}

		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private Controller.FensterXmlController? _Controller = null;

		/// <summary>
		/// Ruft den Dienst zum Speichern bzw. Lesen
		/// der Fensterliste im Xml Format ab
		/// </summary>
		private Controller.FensterXmlController? Controller
		{
			get
			{
				this._Controller ??= this.AppKontext?
						.Produziere<Controller.FensterXmlController>();

				return this._Controller;
			}
		}

	}
}
