using Maui.Erweitert;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.DatenObjekte
{
    /// <summary>
    /// Definiert das Abstrakte Konzept eines Daten-Transfer-Objektes
    /// welches zum austausch zwischen Client-Server-Informationen benutzt wird
    /// </summary>
    public abstract class Dto : ViewModelAppObjekt, IDto
	{
		/// <summary>
		/// Gibt den Index vom Element an
		/// </summary>
		public int Id { get; set; }
	}

	/// <summary>
	/// Definiert die notwendige Schnittstelle für ein Daten-Transfer-Objekt
	/// </summary>
	public interface IDto
	{
		/// <summary>
		/// Muss einen Index beinhalten
		/// </summary>
		int Id { get; set; }
	}

}