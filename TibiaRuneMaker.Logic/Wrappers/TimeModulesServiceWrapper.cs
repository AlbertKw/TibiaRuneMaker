using TibiaRuneMaker.Logic.Interfaces;

namespace TibiaRuneMaker.Logic.Wrappers
{
    public class TimeModulesServiceWrapper
    {
        public readonly Configuration Configuration;
        public readonly ITimeManager TimeManager;
        public readonly IClientInjector ClientInjector;

        public TimeModulesServiceWrapper(Configuration configuration, ITimeManager timeManager, IClientInjector clientInjector)
        {
            Configuration = configuration;
            TimeManager = timeManager;
            ClientInjector = clientInjector;
        }
    }
}