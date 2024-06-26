﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Kern.Erweiterungen
{
	/// <summary>
	/// Stellt diverse Erweiterungsmethoden bereit
	/// </summary>
	public static class Werkzeuge
	{

		/// <summary>
		/// Prüft, ob im Pfad ein Unterordner
		/// für die aktuelle Kultur existiert,
		/// hängt diesen an, falls vorhanden,
		/// und gibt den neuen Pfad zurück.
		/// </summary>
		/// <param name="pfad">Eine Verzeichnisangabe,
		/// in der geprüft werden soll, ob ein
		/// Unterordner für die aktuelle Kultur existiert</param>
		/// <returns>Den Pfad inkl. des Kulturordners
		/// oder den Originalpfad, wenn kein Unterordner
		/// gefunden wurde</returns>
		/// <remarks>Die Gültigkeit des Pfads kann damit
		/// nicht geprüft werden</remarks>
		public static string HoleLokalisiertenOrdner(this string pfad)
		{

			var AktuelleKultur = System.Globalization.CultureInfo.CurrentUICulture.Name;

			while (!System.IO.Directory.Exists(System.IO.Path.Combine(pfad, AktuelleKultur))
				&& AktuelleKultur != string.Empty)
			{
				var PositionLetzterBindestrich = AktuelleKultur.LastIndexOf('-');

				if (PositionLetzterBindestrich != -1)
				{
					AktuelleKultur = AktuelleKultur[..PositionLetzterBindestrich];
				}
				else
				{
					AktuelleKultur = string.Empty;
				}
			}

			return System.IO.Path.Combine(pfad, AktuelleKultur);
		}

	}
}
