using Maui.Kern.Manager.Logging;
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

            LogManager.Info($"{data.GetType()}-JSONController serialized successfully");

        }

        /// <summary>
        /// Läd Daten aus einer Datei
        /// </summary>
        /// <returns></returns>
        public T? Laden(string ausPfad)
		{
            T obj;
            try
			{
				var jsonData = File.ReadAllText(ausPfad);

                obj = JsonConvert.DeserializeObject<T>(jsonData);
                LogManager.Info($"{obj.GetType()}-JSONController deserialized successfully");

            }
            catch (Exception e)
            {

                LogManager.Info($"{typeof(T).Name}-JSONController deserialization had a Problem: {e.StackTrace}");
                return default;
			}

            return obj;
        }
	}
}
