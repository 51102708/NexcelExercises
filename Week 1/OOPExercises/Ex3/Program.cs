﻿namespace Ex3
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            var arrShape = new Shape[]
            {
                new Circle(20),
                new Rectangle(10, 30),
                new Triangle(10, 15)
            };
            arrShape.ToList().ForEach(Console.WriteLine);
            Console.ReadLine();
        }
    }
}