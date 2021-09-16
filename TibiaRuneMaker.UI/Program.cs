using System;
using Microsoft.Extensions.DependencyInjection;
using TibiaRuneMaker.Logic;
using TibiaRuneMaker.Logic.Interfaces;
using TibiaRuneMaker.Logic.Services;
using TibiaRuneMaker.UI.Extensions;

namespace TibiaRuneMaker.UI
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            try
            {
                RegisterServices();
                var scope = _serviceProvider.CreateScope();
                scope.ServiceProvider.GetRequiredService<Application>().Run();
                DisposeServices();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press key to close the application.");
                Console.ReadKey();
            }
        }
        
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Application>();
            services.AddSingleton<Configuration>();
            services.AddSingleton<IClientInjector, ClientInjector>();
            services.AddSingleton<ITimeManager, TimeManager>();
            services.AddModules();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            switch (_serviceProvider)
            {
                case null:
                    return;
                case IDisposable disposable:
                    disposable.Dispose();
                    break;
            }
        }
    }
}
