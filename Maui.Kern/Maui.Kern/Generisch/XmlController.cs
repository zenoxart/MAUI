using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Kern.Generisch
{
	/// <summary>
	/// Stellt einen typsicheren Dienst zum Schreiben
	/// und Lesen einer Datenliste im Xml-Format bereit
	/// </summary>
	public class XmlController<T> : AppObjekt
	{
		/// <summary>
		/// Serialisiert die Daten der
		/// Liste in die angegebene Datei
		/// im Xml Format
		/// </summary>
		/// <param name="liste">Die zu speichernden Daten</param>
		/// <param name="inPfad">Die vollständige Pfadangabe der Xml Datei</param>
		/// <exception cref="System.Exception">Tritt auf, wenn das Serialisieren nicht funktioniert hat</exception>
		public void Speichern(T liste, string inPfad)
		{
			if (liste != null)
			{
				System.Xml.Serialization.XmlSerializer Serialisierer = new(liste.GetType());

				using var Schreiber = new System.IO.StreamWriter(inPfad);

				Serialisierer.Serialize(Schreiber, liste);
			}

		}

		/// <summary>
		/// Gibt die deserialisierten Xml Daten
		/// aus der Datei zurück
		/// </summary>
		/// <param name="ausPfad">Die vollständige Pfadangabe der Xml Datei</param>
		/// <exception cref="System.Exception">Tritt auf, wenn das Deserialisieren nicht funktioniert hat</exception>
		public T? Laden(string ausPfad)
		{
			System.Xml.Serialization.XmlSerializer Serialisierer = new(typeof(T));

			using var Leser = new System.IO.StreamReader(ausPfad);

			return (T)Serialisierer.Deserialize(Leser)!;
		}
	}
}
