using CommunityToolkit.Mvvm.ComponentModel;
using Maui.Erweitert;
using Maui.Kern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.MVVM.Utils
{
	/// <summary>
	/// Stellt die Grundlage für Maui ViewModels
	/// bereit und unterstützt diese mit der Infrastruktur
	/// </summary>
	public class MauiAppObjekt : ViewModelAppObjekt, IAppKontext
	{
        /// <summary>
        /// Ruft die erweiterte Infrastruktur
        /// ab oder legt diese fest
        /// </summary>
        /// <remarks>Als Feld wird der AppKontext
        /// der Basisklasse benutzt. Durch diese
        /// Eigenschaft erspart man sich das
        /// spätere ständige Casten.</remarks>
        public new MauiAppKontext? AppKontext
        {
            get
            {
                return base.AppKontext as MauiAppKontext;
            }
            set
            {
                //Erlaubt, weil MauiAppKontext -> DatenbankAppKontext & -> AppKontext erweitert...
                base.AppKontext = value;
            }
        }
    }
}
