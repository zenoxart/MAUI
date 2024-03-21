using Newtonsoft.Json;
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
	public class JsonController<T> : AppObjekt
	{
		/// <summary>
		/// Speichert die übergeben Daten in eine Datei
		/// </summary>
		/// <param name="data"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public void Speichern(T data, string inPfad)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

			File.WriteAllText(inPfad, jsonData);
		}

		/// <summary>
		/// Läd Daten aus einer Datei
		/// </summary>
		/// <returns></returns>
		public T? Laden(string ausPfad)
		{
			try
			{
				var jsonData = File.ReadAllText(ausPfad);

				return JsonConvert.DeserializeObject<T>(jsonData);
			}
			catch (Exception)
			{
				// Handle file read errors, return default instance, or rethrow the exception
				return default;
			}
		}
	}
}
