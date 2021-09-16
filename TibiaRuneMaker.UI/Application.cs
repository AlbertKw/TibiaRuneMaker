using System.Collections.Generic;
using TibiaRuneMaker.Logic;
using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Interfaces;
using TibiaRuneMaker.UI.Extensions;

namespace TibiaRuneMaker.UI
{
    public class Application
    {
        private readonly List<IModule> _modules;
        
        public Application(ServiceResolver serviceAccessor, Configuration config)
        {
            _modules = new List<IModule>()
            {
                serviceAccessor(ModuleEnum.EatFood),
                serviceAccessor(ModuleEnum.SpellCast),
                serviceAccessor(ModuleEnum.EquipLifeRing),
                serviceAccessor(ModuleEnum.EquipSoftBoots)
            };
        }

        public void Run()
        {
            while (true)
            {
                foreach (var module in _modules)
                {
                    module.Execute();
                    System.Threading.Thread.Sleep(2500);
                }
            }
        }
    }
}
