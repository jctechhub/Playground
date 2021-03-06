﻿using System;
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

            //---- Bad way: 
            var pf = new ProductFilter();
            Console.WriteLine("Green products (OLD):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is green");
            }
            //-----

            //---- Better way: use Specification pattern 
            var bf = new ProductFilterNew();
            Console.WriteLine("Green products (NEW):");
            foreach (var product in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {product.Name} is green.");
            }

            var combinedSpec = new AndSpecification<Product>(new ColorSpecification(Color.Green), new SizeSpecification(Size.Large) );
            Console.WriteLine("Green and Large product: ");
            foreach (var p in bf.Filter(products, combinedSpec))
            {
                Console.WriteLine($" - {p.Name} is Green and Large");
            }
            //-----
        }
    }

    //---- Better way: use Specification pattern 
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == _color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == _size;
        }
    }


    /// <summary>
    /// This the combined spec class. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AndSpecification<T> : ISpecification<T> 
    {
        private ISpecification<T> _spec1, _spec2;

        public AndSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            _spec1 = spec1 ?? throw new Exception("Spec1 can't be null");
            _spec2 = spec2 ?? throw new Exception("Spec2 can't be null");
        }
        public bool IsSatisfied(T t)
        {
            return _spec1.IsSatisfied(t) && _spec2.IsSatisfied(t);
        }
    }

    public class ProductFilterNew : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                    yield return item;
            }
        }
    }
    //---- 

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
