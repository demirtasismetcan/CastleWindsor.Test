using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CastleWindsor.Test.cwLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsor.Test.cwBootstrapContainer
{
    public static class IoC
    {
        private static readonly IWindsorContainer container = new WindsorContainer();

        public static void WriterFactory()
        {
            container.Register(
                Component.For<IWriter>().ImplementedBy<Writer>()
                );
        }

        public static void LogFactory()
        {
            container.Register(
                Component.For<ILog>().ImplementedBy<ConsoleLogger>()
                );
        }

        public static T ResolveMouse<T>()
        {

            return container.Resolve<T>();
        }
    }
}