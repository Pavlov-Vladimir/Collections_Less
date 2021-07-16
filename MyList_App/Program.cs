using System;
using System.Collections.Generic;

namespace MyList_App
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new();
            list.Add(2);
            list.Add(2);
            list.Add(2);
            list.Add(2);
            list.Add(2);
            list.Add(2);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list[3] = 7;
            list[0] = 13;

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
