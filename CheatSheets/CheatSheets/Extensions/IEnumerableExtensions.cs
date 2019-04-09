using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatSheets.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Appends a value to the end of the sequence. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="element">The value to append to source.</param>
        /// <returns>A new sequence that ends with element.</returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T element)
        {
            foreach (var item in source)
            {
                yield return item;
            }
            yield return element;
        }

        /// <summary>
        /// Adds a value to the beginning of the sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="element">The value to prepend to source.</param>
        /// <returns>A new sequence that begins with element</returns>
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T element)
        {
            yield return element;
            foreach (var item in source)
            {
                yield return item;
            }
        }

        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> items)
        {
            IList<T> list = (IList<T>)items;

            if (list == null)
                yield return default(T);

            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }
    }
}
