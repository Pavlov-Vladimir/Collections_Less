using System;
using System.Collections;

namespace Collections_App
{
    class Program
    {
        static IEnumerable GetEvensFromArray(int[] array)
        {
            foreach (int item in array)
            {
                if (item % 2 == 0)
                    yield return item;
            }
        }

        static int[] AddEvens(int[] array)
        {
            int count = 0;
            foreach (int item in GetEvensFromArray(array))
            {
                count++;
            }
            int[] newArray = new int[count];
            count = 0;
            foreach (int item in GetEvensFromArray(array))
            {
                newArray[count++] = item;
            }
            return newArray;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arr2;

            arr2 = AddEvens(arr);

            IEnumerable arr3 = GetEvensFromArray(arr);

            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n" + new string('-', 15));

            foreach (int item in arr2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n" + new string('-', 15));

            foreach (int  item in arr3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
