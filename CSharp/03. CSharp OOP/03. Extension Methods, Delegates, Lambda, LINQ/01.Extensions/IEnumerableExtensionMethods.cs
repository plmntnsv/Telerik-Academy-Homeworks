namespace _03.Extension_Methods_Delegates_Lambda_LINQ._01.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensionMethods
    {
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            T result = default(T);
            foreach (T item in collection)
            {
                result += (dynamic)item;
            }

            return result;
        }

        public static double Product<T>(this IEnumerable<T> collection)
        {
            double result = 1;
            foreach (T item in collection)
            {
                result *= (dynamic)item;
            }

            return result;
        }

        public static T Min<T>(this IEnumerable<T> collection)
        {
            T min = collection.ElementAt(0);
            foreach (T item in collection)
            {
                if ((dynamic)item < min)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection)
        {
            T max = collection.ElementAt(0);
            foreach (T item in collection)
            {
                if ((dynamic)item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> collection)
        {
            T sum = collection.Sum();
            T count = default(T);
            foreach (T item in collection)
            {
                count+= (dynamic)1;
            }
            T average = (dynamic)sum / count;
            return average;
        }
    }
}
