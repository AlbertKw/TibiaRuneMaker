using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Wrappers;

namespace TibiaRuneMaker.Logic.Modules
{
    public class EquipLifeRingModule: AbstractTimeModule
    {
        protected override int Cooldown => ServiceWrapper.Configuration.UserConfiguration.LifeRingCooldown;
        protected override int MinimumRandomTime => ServiceWrapper.Configuration.UserConfiguration.LifeRingMinimumRandomTime;
        protected override int MaximumRandomTime => ServiceWrapper.Configuration.UserConfiguration.LifeRingMaximumRandomTime;
        protected override ModuleEnum Module => ModuleEnum.EquipLifeRing;
        private KeysEnum _key => ServiceWrapper.Configuration.KeyEquipLifeRing;
        
        public EquipLifeRingModule(TimeModulesServiceWrapper serviceWrapper) : base(serviceWrapper) { }
        
        protected override void DoAction()
        {
            ServiceWrapper.ClientInjector.SendKey(_key);
        }
    }
}