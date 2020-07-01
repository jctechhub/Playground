using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraySamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //var test = Console.ReadLine();
            //var test2 = Console.ReadLine(d);
            //Console.WriteLine("TEST IS " + test);
            //Console.WriteLine("TEST2 IS " + test2);

            //-------------------------
            //Sort array []
            int[] intArray = new int[5] { 8, 10, 2, 6, 3 };
            Array.Sort(intArray);
            foreach (int i in intArray) Console.Write(i + " ");  // output: 2 3 6 8 10
            Console.WriteLine("Next------------------");
            //-------------------------



            //-------------------------
            //Sort List[]
            var intList = new List<int>() { 5, 7, 3, 2, 4 };
            intList.Sort();
            foreach (int i in intList) Console.Write(i + " ");
            Console.WriteLine("Next------------------");
            //-------------------------



            //-------------------------
            //difference sort order
            int[] intArray1 = new int[5] { 8, 10, 2, 6, 3 };
            Array.Sort(intArray1);
            Console.WriteLine("Sorting in asc order");
            foreach (int i in intArray1) Console.Write(i + " ");
            Console.WriteLine();
            //-------------------------

            //-------------------------
            Array.Reverse(intArray1);
            Console.WriteLine("Sorting in reverse way");
            foreach (int i in intArray1) Console.Write(i + " ");
            Console.WriteLine();
            Console.WriteLine("Next------------------");
            //-------------------------


            //-------------------------
            //order using linq
            int[] arr = new int[] { 1, 9, 6, 7, 5, 9 };

            // Sort the arr in decreasing order 
            // and return a array 
            arr = arr.OrderByDescending(c => c).ToArray();

            // print all element of array 
            foreach (int value in arr)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            //-------------------------


            //-------------------------
            //Task: find differences in array
            Console.WriteLine("Find differences in 2 arrays");
            int[] arr1 = new int[] { 1, 9, 6, 7, 5, 9 };
            int[] arr2 = new int[] { 1, 10, 6, 2, 9 }; // 10, 7, 5, 2
            var diff1 = arr1.Except(arr2);
            var diff2 = arr2.Except(arr1);
            var combine = diff1.Concat(diff2); //Merge the 2 lists
            foreach (var s in combine) Console.Write(s + " ");
            Console.WriteLine();
            //-------------------------


            //-------------------------
            //Task: 
            Console.WriteLine("Removes duplicate in INT list");
            int[] arr3 = { 1, 2, 3, 3, 4 };
            int[] arr4 = arr3.Distinct().ToArray();
            foreach (var s in arr4) Console.Write(s + " ");
            Console.WriteLine();
            //-------------------------


            //-------------------------
            //Task: 
            Console.WriteLine("Removes duplicate in string list");
            string[] arr5 = { "a", "b", "b", "c", "c", "d", "e", "f", "f" };
            string[] arr6 = arr5.Distinct().ToArray();
            foreach (var s in arr6) Console.Write(s + " ");
            Console.WriteLine();
            //-------------------------



            Console.WriteLine("-------------------------");
            Console.WriteLine("Hello World!");

        }
    }
}
