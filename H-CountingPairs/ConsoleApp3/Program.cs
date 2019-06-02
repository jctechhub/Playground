using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            


           // var arr = new List<int> { 1, 1, 2, 2, 3, 3 };  //good after de-dup
            //var arr = new List<int> { 1, 2, 3, 4, 5, 6 }; // good
            var  arr = new List<int> { 1, 2, 5, 6,9,10 }; // good
            int k = 2;
            Console.WriteLine(countPairsWithDiffK(arr, k));
        }



        static int countPairsWithDiffK(List<int> numbers, int k)
        {
            if (numbers == null || numbers.Count == 0) return 0;

            int count = 0;
            //var temp = new List<KeyValuePair<int,int>>(); //this is to prevent duplicate count. however, this has performance issue. need to work on this. 
            var temp = new Dictionary<int, int>();
            numbers.Sort();
                       
            for (int i = 0; i < numbers.Count; i++)
            {            
                for (int j = i + 1; j < numbers.Count; j++)
                    if (numbers[i] - numbers[j] == k || numbers[j] - numbers[i] == k)
                    {
                        var key = numbers[i];
                        var value = numbers[j];
                        if (numbers[i] > numbers[j])
                        {
                            key = numbers[j];
                            value = numbers[i];
                        }
                        //if (!temp.Exists(x => x.Key == key && value == value))
                        if (! (temp.ContainsKey(key) && temp.ContainsValue(value)))
                        {
                            //  temp.Add(new KeyValuePair<int, int>(key, value));
                            temp.Add(key, value);
                            count++;
                        }
                    }                        
            }

            return count;
        }
    }
}
