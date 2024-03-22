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
    public abstract partial class SammlungManager<T> : MauiAppObjekt where T : IDto, new()
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

        /// <summary>
        /// Gibt eine geordnete Collection zurück
        /// </summary>
        /// <typeparam name="T">Der generische Typ der Collectionobjekte</typeparam>
        /// <param name="liste">Die rohe Collection</param>
        /// <returns>eine sortierte Collection</returns>
        public static ObservableCollection<T> Sortieren<T>(ObservableCollection<T> observableCollection) where T : ISortierbaresObjekt
            => new(observableCollection.OrderBy(x => x.SortierID).ToArray());

        /// <summary>
        /// Gibt eine Collection in umgedrehter Reihenfolge zurück
        /// </summary>
        /// <typeparam name="T">Der generische Typ der Collectionobjekte</typeparam>
        /// <param name="liste">Die rohe Collection</param>
        /// <returns>die umgedrehte Collection</returns>
        public static ObservableCollection<T> SortierungUmdrehen<T>(ObservableCollection<T> queue)
        {
            var neueListe = new ObservableCollection<T>();

            do
            {
                var last = queue.Last();
                neueListe.Add(last);
                queue.Remove(last);

            } while (queue.Count != 0);

            return neueListe;
        }

        /// <summary>
        /// Gibt eine Collection mit allen Dublikaten 2 sets zurück
        /// </summary>
        /// <typeparam name="T">Der generische Typ der Collectionobjekte</typeparam>
        /// <param name="collection1">Die erste Collection</param>
        /// <param name="collection2">Die zu vergleichende Collection</param>
        /// <returns>die Dublikate beider Collections</returns>
        public static ObservableCollection<T> CheckDublikateZwischenCollections<T>(ObservableCollection<T> collection1, ObservableCollection<T> collection2)
        {
            var dublicates = new ObservableCollection<T>();
            foreach (var item in collection1.Where(collection2.Contains))
            {
                dublicates.Add(item);
            }

            return dublicates;
        }


    }
}
