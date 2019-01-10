using EmprestimoQueue.App_Start;
using System;

namespace EmprestimoQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceLocatorConfigure.Configuration();
            Bootstrap.Initialize();

            Console.ReadKey();
        }
    }
}
