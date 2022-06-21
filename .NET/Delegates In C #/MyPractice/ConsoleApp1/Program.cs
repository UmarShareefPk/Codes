using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(getlastName("Umar"));
            return;
            Console.WriteLine("Calculating bonus for 60");
            Console.WriteLine();
            var bonus = Library.Bonus(HowToGetMax,30, comment);
            Console.WriteLine("Bonus for 60 performace is {0}" , bonus);
            Console.ReadKey();
        }
        
        public static void HowToGetMax(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }

        public static void comment(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }

        public static string getlastName(string firstName!!)
        {
            return firstName + " Shareef";
        }

    }
}
