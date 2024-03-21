using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Erweitert.SqlClient
{/// <summary>
 /// Stellt die Grundlage [Basisklasse] für eine Klasse bereit,
 /// die Daten von einem Sql Server liest bzw. schreibt.
 /// </summary>
	public abstract class Controller : ViewModelAppObjekt
	{

		/// <summary>
		/// Ruft den ConnectionString ab, der
		/// zum Verbinden zur Sql Server Datenbank benutzt wird
		/// </summary>
		protected string? ConnectionString
		{
			get;set;
		}
	}
}
