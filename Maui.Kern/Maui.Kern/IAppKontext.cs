using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Kern
{
	/// <summary>
	/// Stellt die Anwendungsinfrastruktur
	/// </summary>
	public interface IAppKontext
	{
		/// <summary>
		/// Ruft die Anwendungsinfrastruktur ab
		/// oder legt diese fest
		/// </summary>
		AppKontext? AppKontext { get; set; }

	}
}
