using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Kern
{
	/// <summary>
	/// Stellt das abstakte Konzept eines Infrastruktur-Objektes welches 
	/// darin instanziiert werden kann
	/// </summary>
	public abstract class AppObjekt : CommunityToolkit.Mvvm.ComponentModel.ObservableObject, IAppKontext
	{
		/// <summary>
		/// Ruft die Infrastruktur ab oder legt diese fest
		/// </summary>
		public AppKontext? AppKontext { get; set; }

		/// <summary>
		/// Wird ausgelöst, wenn eine Ausnahme aufgetreten ist
		/// </summary>
		public event FehlerAufgetretenEventHandler? FehlerAufgetreten;

		/// <summary>
		/// Löst das Ereignis FehlerAufgetreten aus
		/// </summary>
		/// <param name="e">Die Ereignisdaten mit der Ursache</param>
		/// <remarks>Wird FehlerAufgetreten nicht behandelt,
		/// wird die Ausnahme ausgelöst</remarks>
		protected virtual void OnFehlerAufgetreten(FehlerAufgetretenEventArgs e)
		{
			// Version 20201203 Hr. Plaimer
			//                  Damit Fehler sicher in der
			//                  Entwicklung zu einer Reaktion
			//                  führen, abstürzen, wenn
			//                  FehlerAufgetreten nicht behandelt ist

			// Damit beim Multithreading
			// der Garbage Collector das Objekt
			// nicht entfernt, die Speicheradresse kopieren
			var BehandlerKopie = this.FehlerAufgetreten;

			if (BehandlerKopie != null)
			{
				BehandlerKopie(this, e);
			}
			// 20201203 Hr. Plaimer
#if DEBUG
			else if (e.Ursache != null)
			{
				throw e.Ursache;
			}
#endif
		}
	}
}
