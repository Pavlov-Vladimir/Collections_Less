using System;

namespace MyDictionary_App
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> dict = new(5);

            #region Some tests

            dict.Add(1, "Bob");
            dict.Add(2, "33");
            dict.Add(3, "Blabla");

            Console.WriteLine(dict.Capacity + " " + dict.Count);
            Console.WriteLine(dict.ToString());

            Console.WriteLine(dict.ContainsKey(1));
            Console.WriteLine(dict.ContainsKey(7));
            Console.WriteLine(dict.ContainsValue("Bob"));
            Console.WriteLine(dict.ContainsValue("Tom"));

            dict.Remove(5);
            dict.Remove(2);
            dict[3] = "Tom";
            Console.WriteLine(dict.ToString());
            Console.WriteLine(dict[1]);
            Console.WriteLine(dict[2]);

            Console.WriteLine(++dict.Capacity + " " + dict.Count);

            dict.Clear();
            Console.WriteLine(dict.ToString()); 
            #endregion
        }
    }
}
