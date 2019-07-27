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
            var apple = new Product("Apple", Color.Green, Size.small);
            var tree = new Product("tree", Color.Green, Size.Large);
            var house = new Product("house", Color.blue, Size.Large);

            Product[] products = {apple, tree, house};

            var pf = new ProductFilter();
            Console.WriteLine("Green products (OLD):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is green");
            }
            Console.WriteLine("Hello World!");
        }


    }



    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> items, Size size)
        {
            foreach (var p in items)
            {
                if (p.Size == size)
                    yield return p;
            }
        }

        ///PROBLEM: need to add more method in this class to extend the filter functionality. 
        /// it violates the Open/Close principle: open for extension and close for Modifications.  
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> items, Color color)
        {
            foreach (var p in items)
            {
                if (p.Color == color)
                    yield return p;
            }
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

        

}
