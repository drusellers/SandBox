using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fohjin.AppDomainLoader;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Console.WriteLine("Check memory foot print");
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();

            var appDomainRunner = new AppDomainRunner();
            var createNewAssembliesAndUseThem = new CreateNewAssembliesAndUseThem();
            createNewAssembliesAndUseThem.SomethingWasDone += createNewAssembliesAndUseThem_SomethingWasDone;

            int counter = 0;
            while (counter++ < 100)
            {
                appDomainRunner.RunInDifferentAppDomain(createNewAssembliesAndUseThem.CreateAssemblyAndUseIt);
            }

            Console.WriteLine("Check memory foot print");
            Console.WriteLine("Press a key to stop");
            Console.ReadKey();
        }

        static void createNewAssembliesAndUseThem_SomethingWasDone(string message)
        {
            Console.WriteLine(message);
        }
    }
}
