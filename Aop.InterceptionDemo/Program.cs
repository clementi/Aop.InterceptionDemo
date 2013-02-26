using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Aop.InterceptionDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            ConfigureContainer(container);

            var starship = container.Resolve<IStarship>(new ParameterOverride("name", "USS Enterprise"));

            starship.GoToWarp(7.5);
            starship.GoToWarp(10);
            starship.GoToWarp(1);
        }

        private static void ConfigureContainer(IUnityContainer container)
        {
            var config = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            config.Configure(container);
        }
    }
}
