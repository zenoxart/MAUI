
using System.Collections.Generic;
using System.Linq;

namespace Maui.Erweitert.Datenstrukturverwaltung
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten und Handeln von Queues
    /// </summary>
    public abstract class QueueManager : ViewModelAppObjekt
    {
        /// <summary>
        /// Gibt eine geordnete Queue zurück
        /// </summary>
        /// <typeparam name="T">Der generische Typ der Queueobjekte</typeparam>
        /// <param name="liste">Die rohe Queue</param>
        /// <returns>eine sortierte Quere</returns>
        public static Queue<T> Sortieren<T>(Queue<T> queue) where T : ISortierbaresObjekt 
            => new([.. queue.OrderBy(x => x.SortierID)]);


        /// <summary>
        /// Gibt eine Queue mit allen Dublikaten 2 sets zurück
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queue1">Die erste Queue</param>
        /// <param name="queue2">Die zu vergleichende Queue</param>
        /// <returns>die Dublikate beider Queues</returns>
        public static Queue<T> CheckDublikateZwischenQueues<T>(Queue<T> queue1, Queue<T> queue2)
        {
            var dublicates = new Queue<T>();
            foreach (var item in queue1.Where(queue2.Contains))
            {
                dublicates.Enqueue(item);
            }

            return dublicates;
        }

        /// <summary>
        /// Gibt eine Queue zurück welche alle Dublikate der übergebenen Sammlung an Queues besitzt
        /// </summary>
        /// <typeparam name="T">Der generische Typ des Queue-Objektes</typeparam>
        /// <param name="queuecollections">Eine Auflistung an generischen Queue zum Vergleichen</param>
        /// <returns>Die Schnittmenge aller Queueobjekte der übergebenen Sammlung</returns>
        public static Queue<T> CheckAlleDublikate<T>(List<Queue<T>> queuecollections)
        {
            if (queuecollections.Count < 2)
                return new Queue<T>();


            int counter = 0;
            var dublicates = new Queue<T>();

            foreach (Queue<T> item in queuecollections)
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
                        dublicates.Dequeue();
                    }
                }

                counter++;

            }

            return dublicates;

        }
    }
}
