using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using TibiaRuneMaker.Logic;
using TibiaRuneMaker.Logic.Interfaces;
using TibiaRuneMaker.Logic.Models;
using TibiaRuneMaker.Logic.Services;
using TibiaRuneMaker.UI.Extensions;
using System.Text.Json;

namespace TibiaRuneMaker.UI
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            try
            {
                UserConfigurationModel userConfiguration;
                using (var streamReader = new StreamReader("config.json"))
                {
                    var json = streamReader.ReadToEnd();
                    userConfiguration = JsonSerializer.Deserialize<UserConfigurationModel>(json);
                }
                
                RegisterServices(userConfiguration);
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
        
        private static void RegisterServices(UserConfigurationModel userConfiguration)
        {
            var services = new ServiceCollection();
            services.AddSingleton(userConfiguration);
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
