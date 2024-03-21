using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Kern.Komponenten
{
	/// <summary>
	/// Stellt eine Einheit zum Managen von Zeitdaten, Konvertieren und prüfen
	/// </summary>
	public static class ZeitUtility
	{
		/// <summary>
		/// Liefert die Aktuelle Zeit
		/// </summary>
		/// <returns></returns>
		public static DateTime AktuelleDateTime()
		{
			return DateTime.Now;
		}

		/// <summary>
		/// Liefert das Datum im übergebene Format
		/// </summary>
		public static string FormatDateTime(DateTime dateTime, string format = "yyyy-MM-dd HH:mm:ss")
		{
			return dateTime.ToString(format);
		}

		/// <summary>
		/// Prüft ob das Datum in der Zukunft liegt
		/// </summary>
		public static bool IstDatumInZukunft(DateTime dateToCheck)
		{
			return dateToCheck > DateTime.Now;
		}

		/// <summary>
		/// Prüft ob das Datum in der Vergangenheit liegt
		/// </summary>
		public static bool IstDatumInVergangenheit(DateTime dateToCheck)
		{
			return dateToCheck < DateTime.Now;
		}

		/// <summary>
		/// Berechnet das Geburtsdatum
		/// </summary>
		public static int BerechneAlter(DateTime geburtstag)
		{
			int age = DateTime.Now.Year - geburtstag.Year;

			if (DateTime.Now < geburtstag.AddYears(age))
			{
				age--;
			}

			return age;
		}
	}
}
