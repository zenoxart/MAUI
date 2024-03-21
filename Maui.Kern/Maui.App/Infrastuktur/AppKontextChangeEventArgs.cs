using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.Infrastuktur
{
    /// <summary>
    /// Deklariert Event Args wenn sich die Infrastruktur ändert
    /// </summary>
    /// <remarks>
    /// Konstruktor
    /// </remarks>
    /// <param name="newChange"></param>
    public class AppKontextChangeEventArgs(MauiAppKontext newChange) : EventArgs
    {
        /// <summary>
        /// Öffentliches Feld für den Wert
        /// </summary>
        public MauiAppKontext Change { get; } = newChange;
    }
}
