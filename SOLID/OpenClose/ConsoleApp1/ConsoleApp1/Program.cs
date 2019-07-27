using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var apple =new Prodct("Apple")


            Console.WriteLine("Hello World!");
        }


    }

    public enum Color { Red, Green, blue }
    public enum Size { small, Medium, Large}

    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

  

    public class ProductFilter
    {
        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> items, Size size)
        {
            foreach (var p in items)
            {
                if (p.Size == size)
                    yield return p;
            }
        }
    }
    
        

}
