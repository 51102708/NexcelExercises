using System;
using System.Linq;

namespace Ex2
{
    internal class Program
    {
        private static void Main()
        {
            ///// STUDENT
            var arrStudent = new Student[]
            {
                new Student("Quang", "Le Hong", 12),
                new Student("A", "Nguyen Van", 11),
                new Student("B", "Nguyen Van", 8),
                new Student("C", "Nguyen Van", 7),
                new Student("D", "Nguyen Van", 9),
                new Student("E", "Nguyen Van", 6),
                new Student("F", "Nguyen Van", 10),
                new Student("G", "Nguyen Van", 12),
                new Student("H", "Nguyen Van", 11),
                new Student("I", "Nguyen Van", 9)
            };

            var sortedStudent = arrStudent.OrderBy(c => c.Grade).ToArray();
            sortedStudent.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("\n");
            var arrWorker = new Worker[]
            {
                new Worker("Quang", "Le Hong", 5000000, 8),
                new Worker("A", "Nguyen Van", 5000000, 8),
                new Worker("B", "Nguyen Van", 3000000, 4),
                new Worker("C", "Nguyen Van", 4000000, 8),
                new Worker("D", "Nguyen Van", 3000000, 6),
                new Worker("E", "Nguyen Van", 2000000, 8),
                new Worker("F", "Nguyen Van", 2000000, 6),
                new Worker("G", "Nguyen Van", 2000000, 4),
                new Worker("H", "Nguyen Van", 5000000, 4),
                new Worker("I", "Nguyen Van", 5000000, 6)
            };

            var sortedWorker = arrWorker.OrderByDescending(c => c.CalculateMoneyPerHour()).ToArray();
            sortedWorker.ToList().ForEach(Console.WriteLine);
            Console.ReadLine();
        }
    }
}