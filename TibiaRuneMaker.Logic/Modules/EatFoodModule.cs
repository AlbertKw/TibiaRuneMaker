using System;
using System.Threading;
using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Wrappers;

namespace TibiaRuneMaker.Logic.Modules
{
    public class EatFoodModule : AbstractTimeModule
    {
        protected override int Cooldown => ServiceWrapper.Configuration.UserConfiguration.EatFoodCooldown;
        protected override int MinimumRandomTime => ServiceWrapper.Configuration.UserConfiguration.EatFoodMinimumRandomTime;
        protected override int MaximumRandomTime => ServiceWrapper.Configuration.UserConfiguration.EatFoodMaximumRandomTime;
        protected override ModuleEnum Module => ModuleEnum.EatFood;
        private KeysEnum _key => ServiceWrapper.Configuration.KeyEatFood;

        public EatFoodModule(TimeModulesServiceWrapper serviceWrapper) : base(serviceWrapper) { }
        
        protected override void DoAction()
        {
            for (var i = 0; i < 4; i++)
            {
                EatFood();
            }
        }

        private void EatFood()
        {
            var newRandom = new Random().Next(200, 400);
            Thread.Sleep(newRandom);
            ServiceWrapper.ClientInjector.SendKey(_key);
        }
    }
}