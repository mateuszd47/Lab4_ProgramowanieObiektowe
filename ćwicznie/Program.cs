using System;

namespace ćwicznie
{
    public delegate void Print(string firstname, string lastname);
    class Program
    {
        static void Main(string[] args)
        {
            Print printName = (firstname, lastname) =>
            {
                Console.WriteLine(lastname + " " + firstname);
            };


            Print printName2 = delegate (string firstname, string lastname)
            {
                Console.WriteLine(lastname + " " + firstname);
            };


            Print printName3 = PrintName;

            printName("Jan", "Kowalski");
            printName2("Jan", "Kowalski");
            printName3("Jan", "Kowalski");
        }

        public static void PrintJanKowalski(Print print)
        {
            print("Jan", "Kowalski");
        }

        public static void PrintName(string firstname, string lastname)
        {
            Console.WriteLine(lastname + " " + firstname);
        }
    }
}
