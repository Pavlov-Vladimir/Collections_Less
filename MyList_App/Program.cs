using System;
using System.Collections.Generic;

namespace MyList_App
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new();

            #region Some Tests

            list.Add(2);
            list.Add(2);
            list.Add(2);
            list.Add(2);
            list.Add(2);
            list.Add(2);
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n-----------");

            list[3] = 7;
            list[0] = 13;

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n-----------");

            Console.WriteLine("Index of item '7': " + list.IndexOf(7));

            int[] arr = new int[3];
            list.CopyTo(arr);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n-----------");

            list.Remove(5);
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n-----------");

            list.Clear();
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n-----------");
            Console.WriteLine(list.Capacity + " " + list.Count); 
            #endregion

        }
    }
}
