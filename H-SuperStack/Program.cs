using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //int operations_size = 0;
            //operations_size = Convert.ToInt32(Console.ReadLine());
            //string[] operations = new string[operations_size];
            //string operations_item;
            //for (int operations_i = 0; operations_i < operations_size; operations_i++)
            //{
            //    operations_item = Console.ReadLine();
            //    operations[operations_i] = operations_item;
            //}
            var ope = new string[]{"Push 4", "pop", "Push 3", "Push 5", "push 2", "inc 3 1", "pop", "push 1", "inc 2 2", "push 4", "pop", "pop"};
            superStack(ope);
        }


        static void superStack(string[] operations)
        {            
            var stack = new Stack<int>();
            for (var i = 0; i < operations.Length; ++i)
            {                
                var split = operations[i].Split(' ');

                if (string.Compare(split[0], "push", true) == 0)
                {
                    var number = Convert.ToInt32(split[1]);
                    stack.Push(number);
                }
                else if (string.Compare(split[0], "pop", true) == 0 && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (split[0] == "inc")
                {
                    var count = Convert.ToInt32(split[1]);
                    var increment = Convert.ToInt32(split[2]);
                    count = Math.Min(stack.Count, count);
                                       
                    var arr = stack.ToArray();
                    stack = new Stack<int>();

                    for (var a=0; a< arr.Length - count; a++){
                        stack.Push(arr[a]);
                    }                    
                    
                    //for (var j = 0; j < count; ++j)
                    for (var j = count -1 ; j >=0; --j)
                    { //this is not fully working. still have some issues with inc in the 2nd operation
                        arr[j]  += increment;                        
                        stack.Push(arr[j]);
                    }

                }
                PrintTop(stack);
            }
        }


        static void PrintTop(Stack<int> stack)
        {
            if (stack.Count == 0)
            {
                System.Console.WriteLine("EMPTY");
            }
            else
            {
                System.Console.WriteLine("{0}", stack.ToArray()[0]); 
            }
        }
    }
}
