using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Erweitert.Daten
{
    /// <summary>
    /// Ermöglicht das Kapseln einer Methode
    /// ohne den Garbage Collector an der 
    /// Freigabe des Besitzers zu hindern
    /// </summary>
    /// <remarks>
    /// Initialisiert ein SchwacherMethodenVerweis Objekt
    /// </remarks>
    /// <param name="methode">Speicheradresse der Methode,
    /// die als WeakReference gekapselt werden soll,
    /// damit der Garbage Collector nicht am Freigeben 
    /// des Besitzers gehindert wird</param>
    public class SchwacherMethodenVerweis(System.Action methode)
    {
		/// <summary>
		/// Internes Feld für die Eigenschaft
		/// </summary>
		private readonly System.WeakReference _Methode = new(methode);

		/// <summary>
		/// Ruft die gekapselte Methode ab
		/// </summary><remarks>
		/// Null, falls der Besitzer nicht mehr existiert</remarks>
		public System.Action? Methode
		{
			get
			{
				if (this._Methode.IsAlive)
				{

					return this._Methode.Target as System.Action;
				}

				return null;
			}

		}
    }

    /// <summary>
    /// Stellt eine Auflistung von 
    /// SchwacherMethodenVerweis Objekten bereit
    /// </summary>
    public class SchwacherMethodenVerweisListe : System.Collections.Generic.List<SchwacherMethodenVerweis>
	{

	}



}
