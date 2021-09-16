using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Interfaces;
using TibiaRuneMaker.Logic.Modules;
using TibiaRuneMaker.Logic.Wrappers;

namespace TibiaRuneMaker.UI.Extensions
{
    public delegate IModule ServiceResolver(ModuleEnum module);
    
    public static class ModuleServiceExtension
    {
        public static IServiceCollection AddModules(this IServiceCollection services)
        {
            services.AddSingleton<TimeModulesServiceWrapper>();
            services.AddSingleton<EatFoodModule>();
            services.AddSingleton<SpellCastModule>();
            services.AddSingleton<EquipLifeRingModule>();
            services.AddSingleton<EquipSoftBootsModule>();
            services.AddSingleton<ServiceResolver>(serviceProvider => module =>
            {
                switch (module)
                {
                    case ModuleEnum.EatFood:
                        return serviceProvider.GetService<EatFoodModule>();
                    case ModuleEnum.SpellCast:
                        return serviceProvider.GetService<SpellCastModule>();
                    case ModuleEnum.EquipLifeRing:
                        return serviceProvider.GetService<EquipLifeRingModule>();
                    case ModuleEnum.EquipSoftBoots:
                        return serviceProvider.GetService<EquipSoftBootsModule>();
                    default:
                        throw new KeyNotFoundException();
                }
            });
            return services;
        }
    }
}