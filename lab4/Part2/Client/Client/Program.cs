using System;
using System.Runtime.InteropServices;
namespace Client
{
    class Program
    {

        [DllImport("MyDLL.dll")]
        public static extern void FibonacciInit(ulong a, ulong b);
        [DllImport("MyDLL.dll")]
        public static extern bool FibonacciNext();
        [DllImport("MyDLL.dll")]
        public static extern ulong FibonacciCurrent();
        [DllImport("MyDLL.dll")]
        public static extern uint FibonacciIndex();
        static void Main(string[] args)

        {
            FibonacciInit(1, 2);
            Console.WriteLine(FibonacciIndex());
        }
    }
}