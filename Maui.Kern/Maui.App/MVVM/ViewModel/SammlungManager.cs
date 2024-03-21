using CommunityToolkit.Mvvm.ComponentModel;
using Maui.App.Infrastuktur;
using Maui.DatenObjekte;
using Maui.Erweitert.Datenstrukturverwaltung;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.App.MVVM.ViewModel
{
    /// <summary>
    /// Stellt einen Basismanager zum Visualisieren von Daten-Transfer-Objekten, ermöglicht das Laden, Aktuallisieren und Löschen von Elementen
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract partial class SammlungManager<T> : ObservableCollectionManager where T : IDto, new()
    {
        /// <summary>
        /// Ruft das Selektierte Element ab oder legt dieses fest
        /// </summary>
        [ObservableProperty]
		private T? ausgewähltesElement = new();


        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<T>? elementSammlung;

        

    }
}
