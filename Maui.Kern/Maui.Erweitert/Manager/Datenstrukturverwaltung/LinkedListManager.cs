using System;
using System.Collections.Generic;
using System.Linq;

namespace Maui.Erweitert.Datenstrukturverwaltung
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten und Handeln von Verknüpften Listen
    /// </summary>
    public abstract class LinkedListManager : ViewModelAppObjekt
    {
        /// <summary>
        /// Gibt eine geordnete Verknüfte Liste zurück
        /// </summary>
        /// <typeparam name="T">Der generische Typ der Listenobjekte</typeparam>
        /// <param name="liste">Die rohe Liste</param>
        /// <returns>eine sortierte Liste</returns>
        public static LinkedList<T> Sortieren<T>(LinkedList<T> liste) where T : ISortierbaresObjekt 
            => new([.. liste.OrderBy(x => x.SortierID)]);


        /// <summary>
        /// Gibt eine LinkedList mit allen Dublikaten 2 sets zurück
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="linkedList1">Die erste LinkedList</param>
        /// <param name="linkedList2">Die zu vergleichende LinkedList</param>
        /// <returns>die Dublikate beider LinkedLists</returns>
        public static LinkedList<T> CheckDublikateZwischenListen<T>(LinkedList<T> linkedList1, LinkedList<T> linkedList2)
        {
            var dublicates = new LinkedList<T>();
            foreach (var item in linkedList1)
            {
                if (linkedList2.Contains(item))
                {
                    dublicates.Remove(item);
                }
            }
            return dublicates;
        }

        /// <summary>
        /// Gibt eine LinkedList zurück welche alle Dublikate der übergebenen Sammlung an LinkedLists besitzt
        /// </summary>
        /// <typeparam name="T">Der generische Typ des LinkedList-Objektes</typeparam>
        /// <param name="linkedListcollections">Eine Auflistung an generischen LinkedList-Elementen zum Vergleichen</param>
        /// <returns>Die Schnittmenge aller LinkedListobjekte der übergebenen Sammlung</returns>
        public static LinkedList<T> CheckAlleDublikate<T>(List<LinkedList<T>> linkedListcollections)
        {
            if (linkedListcollections.Count < 2)
                return new LinkedList<T>();

            int counter = 0;
            var dublicates = new LinkedList<T>();

            foreach (LinkedList<T> item in linkedListcollections)
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
                        dublicates.RemoveLast();
                    }
                }

                counter++;

            }

            return dublicates;

        }

    }

}
