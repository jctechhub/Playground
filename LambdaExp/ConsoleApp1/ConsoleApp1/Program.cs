using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //sample func method
            Func<int, int> Square = number => number * number;
            Console.WriteLine(Square(5));

            //same as Func<>, recommended by resharper
            int Square1(int number) => number * number;
            Console.WriteLine(Square1(5));
            
        }



    }
}
