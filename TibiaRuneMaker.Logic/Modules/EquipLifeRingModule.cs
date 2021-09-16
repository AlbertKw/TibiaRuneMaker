using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Wrappers;

namespace TibiaRuneMaker.Logic.Modules
{
    public class EquipLifeRingModule: AbstractTimeModule
    {
        protected override int Cooldown => ServiceWrapper.Configuration.LifeRingCooldown;
        protected override int MinimumRandomTime => ServiceWrapper.Configuration.LifeRingMinimumRandomTime;
        protected override int MaximumRandomTime => ServiceWrapper.Configuration.LifeRingMaximumRandomTime;
        protected override ModuleEnum Module => ModuleEnum.EquipLifeRing;
        private KeysEnum _key => ServiceWrapper.Configuration.KeyEquipLifeRing;
        
        public EquipLifeRingModule(TimeModulesServiceWrapper serviceWrapper) : base(serviceWrapper) { }
        
        protected override void DoAction()
        {
            ServiceWrapper.ClientInjector.SendKey(_key);
        }
    }
}