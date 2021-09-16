using System;
using TibiaRuneMaker.Logic.Enums;

namespace TibiaRuneMaker.Logic.Interfaces
{
    public interface ITimeManager
    {
        DateTimeOffset GetCurrentTime();
        DateTimeOffset GetTimer(ModuleEnum timer);
        void UpdateTimer(ModuleEnum timer, DateTimeOffset value);
    }
}