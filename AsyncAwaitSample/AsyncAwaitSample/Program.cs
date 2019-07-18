using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AsyncAwaitSample
{
    class Program
    {
        private const string URL = "https://docs.microsoft.com/en-us/dotnet/csharp/csharp";

        static async Task Main(string[] args)
        {
            Console.WriteLine("==== 1. async sample ======");
            DoSynchronousWork();
            var someTask1 = DoSomethingAsync1();
            DoSynchronousWorkAfterAwait();
            someTask1.Wait(); //this is a blocking call, use it only on Main method
            
            Console.WriteLine("========================================================");

            Console.WriteLine("==== 2. async, wait for all to complete, then do something else ======");
            DoSynchronousWork();
            someTask1 = DoSomethingAsync1();
            var someTask2 = DoSomethingAsync2();
            await Task.WhenAll(someTask1, someTask2);
            DoSynchronousWorkAfterAwait();




            Console.ReadLine();
        }

        public static void DoSynchronousWork()
        {
            // You can do whatever work is needed here
            Console.WriteLine("1. Doing some work synchronously");
        }

        static async Task DoSomethingAsync1() //A Task return type will eventually yield a void
        {
            Console.WriteLine("2. Async task has started...");
            await GetStringAsync1(); // we are awaiting the Async Method GetStringAsync
        }

        static async Task DoSomethingAsync2() //A Task return type will eventually yield a void
        {
            Console.WriteLine("2.2. Async task has started...");
            await GetStringAsync2(); // we are awaiting the Async Method GetStringAsync
        }


        static async Task GetStringAsync1()
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("3. Awaiting the result of GetStringAsync of Http Client...");
                string result = await httpClient.GetStringAsync(URL); //execution pauses here while awaiting GetStringAsync to complete

                //From this line and below, the execution will resume once the above awaitable is done
                //using await keyword, it will do the magic of unwrapping the Task<string> into string (result variable)
                Console.WriteLine("4. The awaited task has completed. Let's get the content length...");
                Console.WriteLine($"5. The length of http Get for {URL}");
                Console.WriteLine($"6. {result.Length} character");
            }
        }
        static async Task GetStringAsync2()
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("3.2. Awaiting the result of GetStringAsync of Http Client...");
                string result = await httpClient.GetStringAsync(URL); //execution pauses here while awaiting GetStringAsync to complete

                //From this line and below, the execution will resume once the above awaitable is done
                //using await keyword, it will do the magic of unwrapping the Task<string> into string (result variable)
                Console.WriteLine("4.2. The awaited task has completed. Let's get the content length...");
                Console.WriteLine($"5.2. The length of http Get for {URL}");
                Console.WriteLine($"6.2. {result.Length} character");
            }
        }
        static void DoSynchronousWorkAfterAwait()
        {
            //This is the work we can do while waiting for the awaited Async Task to complete
            Console.WriteLine("7. While waiting for the async task to finish, we can do some unrelated work...");
            for (var i = 0; i <= 5; i++)
            {
                for (var j = i; j <= 5; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }
}
