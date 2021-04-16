using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            Transport a = new Transport();
            a.PrintInfo();
            Console.WriteLine();
            Transport b = new Transport(1.6, 150, 4);
            b.PrintInfo();
        }
    }
}
