using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CastleWindsor.Test.cwApp;
using CastleWindsor.Test.cwBootstrapContainer;
using CastleWindsor.Test.cwLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsor.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            getMenu();
            string proc = Console.ReadLine();
            runMethod(proc);
            Console.ReadLine();
        }

        static void getMenu()
        {
            Console.WriteLine("1.Use main method");
            Console.WriteLine("2.Use Bootstrap Container");
        }

        static void useInCont()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<ILog>().ImplementedBy<ConsoleLogger>());
            container.Register(Component.For<IWriter>().ImplementedBy<Writer>());
            container.Register(Component.For<Application>());
            //container.Register(Component.For<ISingleton>().ImplementedBy<Singleton>().LifestyleTransient());
            //container.Register(Classes.FromThisAssembly()
            //    .InNamespace("CastleWindsor.Test.cwLog").WithServiceDefaultInterfaces());     
            var app = container.Resolve<Application>();
            app.Run();
        }

        static void bootstrapContainer()
        {
            IoC.LogFactory();

            IoC.ResolveMouse<ILog>().Info("Hello World..");
        }

        static void runMethod(string proc)
        {
            switch (proc)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Main method running...");
                    useInCont();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Bootstrap Container running...");
                    bootstrapContainer();
                    break;
                default:
                    Console.WriteLine("You have chosen an undefined value.Please,select \"1\" or \"2\"...");
                    getMenu();
                    break;
            }
        }
    }
}
