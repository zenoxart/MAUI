﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Erweitert.Daten
{/// <summary>
 /// Kennzeichnet Eigenschaften von
 /// Datenbasis Objekten, deren Inhalt
 /// im ToString() Ergebnis angezeigt 
 /// werden soll
 /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class InToStringAttribute : System.Attribute
	{
		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private readonly int _Index = 0;

		/// <summary>
		/// Ruft die Position der
		/// Eigenschaft im ToString Ergebnis ab
		/// </summary>
		public int Index
		{
			get
			{
				return this._Index;
			}
		}

		/// <summary>
		/// Initialisiert ein neues InToStringAttribute Objekt
		/// </summary>
		public InToStringAttribute()
		{

		}

		/// <summary>
		/// Initialisiert ein neues InToStringAttribute Objekt
		/// </summary>
		/// <param name="index">Gibt die Position
		/// der Eigenschaft im ToString() Ergebnis an</param>
		public InToStringAttribute(int index)
		{
			this._Index = index;
		}
	}

	/// <summary>
	/// Stellt die Grundlage für ein
	/// Anwendungs Datentransferobjekt bereit
	/// </summary>
	/// <remarks>Objekte basierend auf der DatenBasis
	/// können für die MAUI Datenbindung benutzt werden</remarks>
	public abstract class DatenBasis :  System.ComponentModel.INotifyPropertyChanged
	{
		/// <summary>
		/// Wird ausgelöst, wenn sich der Inhalt
		/// einer Eigenschaft ändert
		/// </summary>
		/// <remarks>Wird von Maui benötigt, damit
		/// die Oberfläche automatisch aktualisiert wird.
		/// Maui prüft das Interface INotifyPropertyChanged</remarks>
		public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// Löst das Ereignis PropertyChanged aus
		/// </summary>
		/// <param name="eigenschaft">Der Name der Eigenschaft,
		/// deren Wert geändert wurde</param>
		/// <remarks>Sollte der Name der Eigenschaft nicht angegeben
		/// werden, wird der Name vom Aufrufer benutzt</remarks>
		protected virtual void OnPropertyChanged(
			[System.Runtime.CompilerServices.CallerMemberName] string eigenschaft = "")
		{
			// Wegen des Multithreadings mit einer 
			// Kopie vom Ereignisbehandler arbeiten
			this.PropertyChanged?.Invoke(
					this,
					new System.ComponentModel.PropertyChangedEventArgs(eigenschaft));
		}

		#region ToString() - Unterstützung

		/// <summary>
		/// Stellt Information über eine Eigenschaft
		/// bereit, deren Wert im ToString() aufgelistet 
		/// werden soll
		/// </summary>
		private sealed class InToStringEigenschaftBeschreibung
		{

			// 20210223 Hr. Plaimer
			//          Index Eigenschaft zum Sortieren
			//          mit Hilfe vom InToStringAttribute ergänzt

			/// <summary>
			/// Ruft die Position dieser Eigenschaft
			/// im ToString Ergebnis ab oder legt
			/// diese fest.
			/// </summary>
			public int Index { get; set; }

			/// <summary>
			/// Ruft die .Net Beschreibung der
			/// Eigenschaft ab oder legt diese fest.
			/// </summary>
			public System.Reflection.PropertyInfo? Eigenschaft { get; set; }

			/// <summary>
			/// Gibt einen Text zurück, der
			/// die gekapselte .Net Eigenschaft beschreibt
			/// </summary>
			public override string? ToString() => this.Eigenschaft?.ToString();

			/// <summary>
			/// Internes Feld für das Ausgabeformat
			/// </summary>
			private string? _Ausgabemuster = null;

			/// <summary>
			/// Ruft den Namen der Eigenschaft
			/// mit einem Parameter für den
			/// aktuellen Wert ab
			/// </summary>
			/// <remarks>Es wird automatisch
			/// ein Komma und Leerzeichen angehängt</remarks>
			public string Ausgabemuster
			{
				get
				{
                    // Den Datentyp unterscheiden,
                    // damit z. B. ein Text unter Anführungszeichen steht
                    this._Ausgabemuster ??= (this.Eigenschaft?.PropertyType.FullName) switch
                    {
                        "System.String" => this.Eigenschaft.Name + "=\"{0}\", ",// Vorsicht: Nicht mit der impliziten 
                                                                                //           Textersetzung arbeiten (-> $"...),
                                                                                //           weil im Ergebnis {0} erhalten bleiben muss
                        _ => this.Eigenschaft?.Name + "={0}, ",
                    };

                    return this._Ausgabemuster;
				}
			}

			/// <summary>
			/// Internes Feld für die Eigenschaft
			/// </summary>
			private string? _AusgabemusterWennNull = null;

			/// <summary>
			/// Ruft den Namen der Eigenschaft
			/// mit der Einstellung Null ab,
			/// wenn kein aktueller Wert vorhanden ist
			/// </summary>
			/// <remarks>Es wird automatisch ein
			/// Komma und Leerzeichen angehängt</remarks>
			public string AusgabemusterWennNull
			{
				get
				{
					this._AusgabemusterWennNull ??= $"{this.Eigenschaft?.Name}=null, ";

					return this._AusgabemusterWennNull;
				}
			}
		}

		/// <summary>
		/// Stellt eine typsichere Auflistung von
		/// InToStringEigenschaftBeschreibung Objekten bereit
		/// </summary>
		private sealed class InToStringEigenschafBeschreibungen
			: System.Collections.Generic.List<InToStringEigenschaftBeschreibung>
		{

		}

		/// <summary>
		/// Stellt eine typsichere Hashtable zum
		/// Sammeln der InToStringEigenschaftBeschreibungen
		/// je Typ bereit.
		/// </summary>
		private sealed class InToStringEigenschaftBeschreibungenWörterbuch
			: System.Collections.Generic.Dictionary<string, InToStringEigenschafBeschreibungen>
		{

		}

		/// <summary>
		/// Internes Hashtable Feld zum Sammeln
		/// der bereits analysierten Typen
		/// </summary>
		private static InToStringEigenschaftBeschreibungenWörterbuch? _InToStringCache = null;

		/// <summary>
		/// Ruft das Wörterbuch zum Sammeln
		/// der Typen mit InToStringAttribute 
		/// Eigenschaften ab
		/// </summary>
		private static InToStringEigenschaftBeschreibungenWörterbuch InToStringCache
		{
			get
			{
				DatenBasis._InToStringCache ??= new InToStringEigenschaftBeschreibungenWörterbuch();

				return DatenBasis._InToStringCache;
			}
		}

		#endregion ToString() - Unterstützung

		/// <summary>
		/// Gibt einen Text zurück, der
		/// das aktuelle Objekt beschreibt.
		/// </summary>
		/// <remarks>Das Ergebnis kann
		/// mit dem InToStringAttribute 
		/// gesteuert werden</remarks>
		public override string? ToString()
		{

			// 20210223 Hr. Plaimer
			//          Die Reihenfolge der Eigenschaften
			//          im ToString kann vorgegeben werden

			// Falls keine Eigenschaften InToStringAttribute
			// besitzen, die Standardrückgabe
			var Ergebnis = base.ToString();

			// Prüfen, ob der aktuelle Typ
			// bereits analysiert ist
			string TypSchlüssel = this.GetType().FullName ?? string.Empty;

			var InToStringEigenschaften
				= InToStringCache.TryGetValue(TypSchlüssel, out InToStringEigenschafBeschreibungen? value) ? value : null;

			// Falls nicht, bei allen
			// Eigenschaften feststellen,
			// ob InToStringAttribute vorhanden ist
			if (InToStringEigenschaften == null)
			{
				InToStringEigenschaften = new InToStringEigenschafBeschreibungen();

				foreach (var e in this.GetType().GetProperties())
				{
					// 20210223 Den Index zum Sortieren berücksichtigen

					var InToStringAttribut = e.GetCustomAttributes(typeof(InToStringAttribute), inherit: true);
					if (InToStringAttribut.Length > 0)
					{
						// Wenn ja, diese Eigenschaft merken
						InToStringEigenschaften.Add(
							new InToStringEigenschaftBeschreibung
							{
								Eigenschaft = e,
								Index = ((InToStringAttribute)InToStringAttribut[0]).Index
							});
					}
				}

				// 20210223 Vor dem Cachen die Liste nach dem Index sortieren
				var EigenschaftenSortiert = (from e in InToStringEigenschaften
											 orderby e.Index
											 select e).ToArray();
				InToStringEigenschaften.Clear();
				InToStringEigenschaften.AddRange(EigenschaftenSortiert);

				// und das Ergebnis der Analyse cachen
				DatenBasis.InToStringCache.Add(TypSchlüssel, InToStringEigenschaften);

				DatenBasis.OnNeuerTypWurdeAnalysiert(this.GetType());
			}

			if (InToStringEigenschaften.Count > 0)
			{
				// Einen Ergebnistext berechnen,
				// in dem die aktuelle Werte
				// der Eigenschaften mit InToStringAttribute
				// eingesetzt werden

				// Falls Eigenschaften eingesetzt werden,
				// nur den Namen der Klasse ohne Namespace,
				// damit das Ergebnis nicht zu lange wird.
				// Außerdem wird kein StringBuilder benutzt,
				// weil das Produzieren den Aufwand bei
				// 1, 2 Eigenschaften nicht rechtfertigt
				Ergebnis = this.GetType().Name + "(";


				foreach (var e in InToStringEigenschaften)
				{
					var AktuellerWert = e.Eigenschaft?.GetValue(this);
					new StringBuilder(Ergebnis).Append(AktuellerWert != null ?
						string.Format(e.Ausgabemuster, AktuellerWert) :
						e.AusgabemusterWennNull);
				}

				// Vor dem Schließen der Klammer
				// die überflüssigen Zeichen "Beistrich und Leer"
				// von den Ausgabemustern entfernen
				Ergebnis = Ergebnis.TrimEnd(' ', ',') + ")";
			}

			// Das Ergebnis zurückgeben
			return Ergebnis;
		}

		/// <summary>
		/// Wird ausgelöst, wenn ToString() einen neuen Typ 
		/// zum Finden der Eigenschaften mit InToStringAttribute
		/// analysiert hat
		/// </summary>
		public static event System.ComponentModel.AddingNewEventHandler? NeuerTypWurdeAnalysiert;

		/// <summary>
		/// Löst das Ereignis NeuerTypWurdeAnalysiert aus
		/// </summary>
		/// <param name="typ">Die Beschreibung des Typs,
		/// der für ToString() analysiert wurde</param>
		protected static void OnNeuerTypWurdeAnalysiert(Type typ)
		{
			if (DatenBasis.NeuerTypWurdeAnalysiert != null)
			{
				NeuerTypWurdeAnalysiert(
					null,
					new System.ComponentModel.AddingNewEventArgs(typ)
					);
			}
		}
	}
}
