﻿using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Wrappers;

namespace TibiaRuneMaker.Logic.Modules
{
    public class EquipSoftBootsModule : AbstractTimeModule
    {
        protected override int Cooldown => ServiceWrapper.Configuration.SoftBootsCooldown;
        protected override int MinimumRandomTime => ServiceWrapper.Configuration.SoftBootsMinimumRandomTime;
        protected override int MaximumRandomTime => ServiceWrapper.Configuration.SoftBootsMaximumRandomTime;
        protected override ModuleEnum Module => ModuleEnum.EquipSoftBoots;
        private KeysEnum _key => ServiceWrapper.Configuration.KeyEquipSoftBoots;
        
        public EquipSoftBootsModule(TimeModulesServiceWrapper serviceWrapper) : base(serviceWrapper) { }
        
        protected override void DoAction()
        {
            ServiceWrapper.ClientInjector.SendKey(_key);
        }
        
    }
}