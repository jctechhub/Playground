using System;

namespace DelegateSample
{
    class Program
    {
        delegate void Test(string name);

        static void Main(string[] args)
        {
            Test t = new Test(Show);
            t.Invoke("Bob");
            t("John");

            t += new Test(Display);  //Multi-casting: this will call 'Show', and then Call 'Display'. 
            t += new Test(Display); // this will not trigger 'Show' call, only 'Display' call. 
            t -= new Test(Display);  //remove the reference. 
            t("Jenny");

            Console.WriteLine("Hello World!");
        }

        static void Show(string name){
            Console.WriteLine("Show Hello " + name);
        }

        static void Display(string name){
            Console.WriteLine("Display Hello " + name);
        }
    }
}
