using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relogger.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            var installer = new Installer();
            container.Install(installer);

            var target = container.Resolve<TargetClass>();

            var result = target.Gcd(3928492, 9424308);

            System.Console.WriteLine("Result: " + result);

            System.Console.Read();
        }
    }

    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ReloggerInterceptor>()
                                        .LifestyleSingleton());

            container.Register(Component.For<TargetClass>()
                                        .Interceptors<ReloggerInterceptor>()
                                        .LifestyleTransient());
        }
    }
}
