using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator cc = new Calculator();
            Console.WriteLine(cc.Add(3, 2));
            Console.ReadLine();
        }
    }
}
