using System;
using VendaQueue.App_Start;

namespace VendaQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrap.Initialize();
            Console.ReadKey();
        }
    }
}
