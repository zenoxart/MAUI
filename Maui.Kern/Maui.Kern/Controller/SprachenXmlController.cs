using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Kern.Controller
{
	/// <summary>
	/// Stellt einen Dienst zum Lesen 
	/// und Schreiben von Sprachen 
	/// im Xml-Format bereit
	/// </summary>
	internal class SprachenXmlController : Generisch.XmlController<Daten.Sprachen>
	{
		/// <summary>
		/// Gibt die Liste der Sprachen
		/// aus den Ressourcen zurück
		/// </summary>
		public static Daten.Sprachen HoleStandardListe()
		{
			var Sprachen = new Daten.Sprachen();
			var Xml = new System.Xml.XmlDocument();

			Xml.LoadXml(Maui.Kern.Properties.Resources.Sprachen);

			IEnumerable<Daten.Sprache> collection()
			{
				if (Xml.DocumentElement != null)
				{
					foreach (System.Xml.XmlNode e in Xml.DocumentElement.ChildNodes)
					{
						if (e.Attributes != null)
						{
							yield return new Daten.Sprache
							{
								Code = e.Attributes?.GetNamedItem("code")?.Value ?? string.Empty,
								Name = e.Attributes?.GetNamedItem("name")?.Value ?? string.Empty
							};
						}

					}
				}

			}

			Sprachen.AddRange(collection());

			return Sprachen;
		}
	}
}
