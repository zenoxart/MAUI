using Maui.Erweitert;
using Maui.Erweitert.Datenstrukturverwaltung;
using System.Collections.Generic;
using System.Linq;

namespace Maui.Erweitert.Datenstrukturverwaltung
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten und Handeln von HashMaps
    /// </summary>
    public abstract class HashMapManager : ViewModelAppObjekt
    {
        /// <summary>
        /// Gibt eine geordnete HashMap/HashSet zurück
        /// </summary>
        /// <typeparam name="T">Der generische Typ des HashSet-Objektes</typeparam>
        /// <param name="hashmap">Die rohe HashMap</param>
        /// <returns>eine sortierte HashMap</returns>
        public static HashSet<T> Sortieren<T>(HashSet<T> hashmap) where T : ISortierbaresObjekt 
            => new([.. hashmap.OrderBy(x => x.SortierID)]);

        /// <summary>
        /// Gibt eine sortierte-HashMap in umgedrehter Reihenfolge zurück
        /// </summary>
        /// <typeparam name="T">Der generische Typ des HashMap-Objektes</typeparam>
        /// <param name="liste">Die rohe HashMap</param>
        /// <returns>die umgedrehte sortierte HashMap</returns>
        public static HashSet<T> SortierungUmdrehen<T>(HashSet<T> hashmap) where T : ISortierbaresObjekt 
            => new([.. hashmap.OrderByDescending(x => x.SortierID)]);

        /// <summary>
        /// Gibt eine HashMap mit allen Dublikaten 2 sets zurück
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        /// <returns></returns>
        public static HashSet<T> CheckDublikateZwischenSets<T>(HashSet<T> map1, HashSet<T> map2)
        {
            var dublicates = new HashSet<T>();
            foreach (var item in map1.Where(map2.Contains))
            {
                dublicates.Add(item);
            }

            return dublicates;
        }

        /// <summary>
        /// Gibt eine HashMap zurück welche alle Dublikate der übergebenen Sammlung an HashMaps besitzt
        /// </summary>
        /// <typeparam name="T">Der generische Typ des HashMap-Objektes</typeparam>
        /// <param name="hashmapcollections">Eine Auflistung an generischen HashMaps zum Vergleichen</param>
        /// <returns>Die Schnittmenge aller HashMapObjekte der übergebenen hashmapcollections</returns>
        public static HashSet<T> CheckAlleDublikate<T>(List<HashSet<T>> hashmapcollections)
        {

            if (hashmapcollections.Count < 2)
                return [];


            int counter = 0;
            var dublicates = new HashSet<T>();

            foreach (HashSet<T> item in hashmapcollections)
            {
                if (counter == 0)
                {
                    dublicates = item;
                }
                else
                {
                    var last = dublicates.Last();
                    if (!item.Contains(last))
                    {
                        dublicates.Remove(last);
                    }
                }

                counter++;

            }

            return dublicates;
        }
    }
}
