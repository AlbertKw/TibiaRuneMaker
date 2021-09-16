using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Wrappers;

namespace TibiaRuneMaker.Logic.Modules
{
    public class SpellCastModule : AbstractTimeModule
    {
        protected override int Cooldown => ServiceWrapper.Configuration.CastSpellCooldown;
        protected override int MinimumRandomTime => ServiceWrapper.Configuration.CastSpellMinimumRandomTime;
        protected override int MaximumRandomTime => ServiceWrapper.Configuration.CastSpellMaximumRandomTime;
        protected override ModuleEnum Module => ModuleEnum.SpellCast;
        
        private KeysEnum _key => ServiceWrapper.Configuration.KeySpellCast;

        public SpellCastModule(TimeModulesServiceWrapper serviceWrapper) : base(serviceWrapper) { }
        
        protected override void DoAction()
        {
            ServiceWrapper.ClientInjector.SendKey(_key);
        }
    }
}