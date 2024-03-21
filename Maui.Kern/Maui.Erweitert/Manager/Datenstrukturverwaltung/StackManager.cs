using System.Collections.Generic;
using System.Linq;

namespace Maui.Erweitert.Datenstrukturverwaltung
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten und Handeln von Stacks
    /// </summary>
    public abstract class StackManager : ViewModelAppObjekt
    {
        /// <summary>
        /// Gibt eine geordnete Stack zurück
        /// </summary>
        /// <typeparam name="T">Der generische Typ der Stackobjekte</typeparam>
        /// <param name="liste">Die rohe Stack</param>
        /// <returns>eine sortierte Quere</returns>
        public static Stack<T> Sortieren<T>(Stack<T> stack) where T : ISortierbaresObjekt 
            => new([.. stack.OrderBy(x => x.SortierID)]);

        /// <summary>
        /// Gibt eine Stack in umgedrehter Reihenfolge zurück
        /// </summary>
        /// <typeparam name="T">Der generische Typ der Stackobjekte</typeparam>
        /// <param name="liste">Die rohe Stack</param>
        /// <returns>die umgedrehte Stack</returns>
        public static Stack<T> SortierenUmdrehen<T>(Stack<T> stack)
        {
            var neueListe = new Stack<T>();

            do
            {
                var last = stack.Pop();
                neueListe.Push(last);


            } while (stack.Count != 0);

            return neueListe;
        }

        /// <summary>
        /// Gibt eine Stack mit allen Dublikaten 2 sets zurück
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stack1">Die erste Stack</param>
        /// <param name="stack2">Die zu vergleichende Stack</param>
        /// <returns>die Dublikate beider Stacks</returns>
        public static Stack<T> CheckDublikateZwischenStacks<T>(Stack<T> stack1, Stack<T> stack2)
        {
            var dublicates = new Stack<T>();
            foreach (var item in stack1.Where(stack2.Contains))
            {
                dublicates.Push(item);
            }

            return dublicates;
        }

        /// <summary>
        /// Gibt eine Stack zurück welche alle Dublikate der übergebenen Sammlung an Stacks besitzt
        /// </summary>
        /// <typeparam name="T">Der generische Typ des Stack-Objektes</typeparam>
        /// <param name="stackcollections">Eine Auflistung an generischen Stack zum Vergleichen</param>
        /// <returns>Die Schnittmenge aller Stackobjekte der übergebenen Sammlung</returns>
        public static Stack<T> CheckAlleDublikate<T>(List<Stack<T>> stackcollections)
        {

            if (stackcollections.Count < 2)
                return new Stack<T>();


            int counter = 0;
            var dublicates = new Stack<T>();

            foreach (Stack<T> item in stackcollections)
            {
                if (counter == 0)
                {
                    dublicates = item;
                }
                else
                {
                    var first = dublicates.First();
                    if (!item.Contains(first))
                    {
                        dublicates.Pop();
                    }
                }

                counter++;

            }

            return dublicates;

        }
    }
}
