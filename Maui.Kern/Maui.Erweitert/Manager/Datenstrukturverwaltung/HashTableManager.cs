using Maui.Erweitert;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Maui.Erweitert.Datenstrukturverwaltung
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten und Handeln von Hashtables
    /// </summary>
    public abstract class HashTableManager : ViewModelAppObjekt
    {
        /// <summary>
        /// Gibt eine sortierte-HashMap in umgedrehter Reihenfolge zurück
        /// </summary>
        /// <typeparam name="T">Der generische Typ des HashMap-Objektes</typeparam>
        /// <param name="liste">Die rohe HashMap</param>
        /// <returns>die umgedrehte sortierte HashMap</returns>
        public static Hashtable? SortierungUmdrehen(Hashtable hashmap) 
            => ((List<object>)[.. hashmap.Values])
                    .OrderByDescending(
                        x => x.ToString()) is IDictionary reorderedList 
                            ? new Hashtable(d: reorderedList) 
                            : null;

        /// <summary>
        /// Gibt eine HashMap mit allen Dublikaten von 2 sets zurück
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        /// <returns></returns>
        public static Hashtable CheckDublikateZwischenSets(Hashtable map1, Hashtable map2)
        {
            var dublicates = new Hashtable();
            int count = 0;
            foreach (var item in map1.Values)
            {
                if (BeinhaltetInHashtable(map2, item))
                {
                    dublicates.Add(count, item);
                    count++;
                }
            }
            return dublicates;
        }

        /// <summary>
        /// Gibt einen Wahrheitswert ob das Objekt in dem Hashtable vorhanden ist oder nicht
        /// </summary>
        private static bool BeinhaltetInHashtable(Hashtable hashtable, object element)
        {
            foreach (var item in hashtable.Values)
            {
                if (element == item)
                {
                    return true;

                }
            }
            return false;
        }

    }
}
