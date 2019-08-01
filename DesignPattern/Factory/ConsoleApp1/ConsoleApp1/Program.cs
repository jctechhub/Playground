using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Point(1.0, 2.0, CoordinateSystem.Cartesian);
            Console.WriteLine($"normal way: {p}");
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


}
