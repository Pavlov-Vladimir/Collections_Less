using System;

namespace MyDictionary_App
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> dict = new(5);

            dict.Add(1, "Bob");
            dict.Add(2, "33");
            dict.Add(3, "Blabla");

            Console.WriteLine(dict.Capacity + " " + dict.Count);
            Console.WriteLine(dict.ToString());
        }
    }
}
