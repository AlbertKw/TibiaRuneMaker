using System;
using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Interfaces;
using TibiaRuneMaker.Logic.Wrappers;
namespace TibiaRuneMaker.Logic.Modules
{
    public abstract class AbstractTimeModule : IModule
    {
        protected readonly TimeModulesServiceWrapper ServiceWrapper;
        protected abstract int Cooldown { get; }
        protected abstract int MinimumRandomTime { get; }
        protected abstract int MaximumRandomTime { get; }
        protected abstract ModuleEnum Module { get; }
        
        public AbstractTimeModule(TimeModulesServiceWrapper serviceWrapper)
        {
            ServiceWrapper = serviceWrapper;
        }

        public bool Execute()
        {
            var currentTime = ServiceWrapper.TimeManager.GetCurrentTime();
            var timer = ServiceWrapper.TimeManager.GetTimer(Module);

            if (currentTime <= timer) { return false; }
            DoAction();
            var random = new Random().Next(MinimumRandomTime, MaximumRandomTime);
            var newTimeValue = currentTime.AddSeconds(Cooldown + random).LocalDateTime;
            var newTimer = new DateTimeOffset(newTimeValue);
            ServiceWrapper.TimeManager.UpdateTimer(Module, newTimer);
            return true;

        }

        protected abstract void DoAction();
    }
}