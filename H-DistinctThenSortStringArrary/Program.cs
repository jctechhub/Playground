using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var list = new List<string>() { 
                "Alex",
                "Michael",
                "Harry",
                "Dave",
                "Michael",
                "Victor",
                "Harry",
                "Alex",
                "Mary",
                "Mary"
                };

            Console.WriteLine(writeIn(list));

        }

        public static string writeIn(List<string> ballot)
        {
            if (ballot == null || ballot.Count == 0) return "";
            
            var maxNumber= ballot.GroupBy(x => x)
                .Select(g => new {key = g.Key, Count = g.Count()})
                .Max(m => m.Count);
            var result = ballot.GroupBy(x => x)
                .Select(g => new { key = g.Key, Count = g.Count() })
                .Where(k=>k.Count == maxNumber)
                .Select(x=>x.key)
                .ToList();
            result.Sort();
            return result.Last();
        }

    }
}
