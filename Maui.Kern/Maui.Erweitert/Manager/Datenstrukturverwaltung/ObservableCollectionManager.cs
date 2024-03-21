using System.Collections.ObjectModel;
using System.Linq;

namespace Maui.Erweitert.Datenstrukturverwaltung
{
    /// <summary>
    /// Stellt eine Basis zum Ordnen, Umdrehen und Checken von Dublikaten in Bindbaren Sammlungen
    /// </summary>
    public abstract class ObservableCollectionManager : ViewModelAppObjekt
    {
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
