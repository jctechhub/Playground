using System.Transactions;
using System;
using System.Collections.Generic;

namespace CountingChar
{
    class Program
    {
        static void Main(string[] args)
        {

            var test = "Hello world";
            var result = GetCharacterCount(test);


            Console.WriteLine("Hello World!");
        }


        public static Dictionary<char, int> GetCharacterCount(string name)
        {
            var result = new Dictionary<char, int>();
            foreach (char c in name)
            {
                if (c.ToString() != " ")
                {
                    int value = 0;
                    var keyExists = result.TryGetValue(Char.ToLower(c), out value);
                    if (keyExists)
                    {
                        result[Char.ToLower(c)] = value + 1;
                    }
                    else
                    {
                        result[Char.ToLower(c)] = 1;
                    }
                }
            }
            return result;
        }


    }
}
