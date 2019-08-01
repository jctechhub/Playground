using System;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Point(1.0, 2.0, CoordinateSystem.Cartesian); //bad way: by creating objects like this, we need to bind the enum to the constructors. 
            Console.WriteLine($"normal way: {p}");

            var p1 = Point.NewCartesianPoint(2, 3);
            Console.WriteLine($"factory method 1: {p1}");

            var p2 = Point.Factory.NewCartesianPoint(3, 4);
            Console.WriteLine($"factory method 2: {p2}");

            var p3 = PointFactory.NewCartesianPoint(4, 5);
            Console.WriteLine($"factory method 3: {p3}");

        }
    }


    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public class Point
    {
        private double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }



        // factory method

        public static Point NewCartesianPoint(double x, double y)
        {
            //new implementation of Cartesian point
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            //new implementation of Polar point
            return null;
        }

        // make it lazy, this is similar to .NET method: Task.Factory.xxx
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }
        }

        /// <summary>
        /// Bad way of creating object, by passing in enum to determine what type. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="cs"></param>
        public Point(double a,
            double b, // names do not communicate intent
            CoordinateSystem cs = CoordinateSystem.Cartesian)
        {
            switch (cs)
            {
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    x = a;
                    y = b;
                    break;
            }

            // steps to add a new system
            // 1. augment CoordinateSystem
            // 2. change ctor
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }

    class PointFactory
    {
        public static Point NewCartesianPoint(float x, float y)
        {
            return new Point(x, y); // needs to be public
        }
    }
}
