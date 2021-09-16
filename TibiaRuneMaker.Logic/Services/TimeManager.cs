using System;
using System.Collections.Generic;
using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Interfaces;

namespace TibiaRuneMaker.Logic.Services
{
    public class TimeManager : ITimeManager
    {
        private readonly Dictionary<ModuleEnum, DateTimeOffset> _timers = new Dictionary<ModuleEnum, DateTimeOffset>()
        {
            {ModuleEnum.SpellCast, new DateTimeOffset()},
            {ModuleEnum.EatFood, new DateTimeOffset()},
            {ModuleEnum.EquipLifeRing, new DateTimeOffset()},
            {ModuleEnum.EquipSoftBoots, new DateTimeOffset()},
        };

        public DateTimeOffset GetCurrentTime()
        {
            return DateTimeOffset.Now;
        }
        
        public DateTimeOffset GetTimer(ModuleEnum timer)
        {
            CheckTimerExist(timer);
            return _timers[timer];
        }

        public void UpdateTimer(ModuleEnum timer, DateTimeOffset value)
        {
            CheckTimerExist(timer);
            _timers[timer] = value;
        }

        private void CheckTimerExist(ModuleEnum timer)
        {
            if (!_timers.ContainsKey(timer))
            {
                throw new ArgumentException("Timer doesn't exist.");
            }
        }
    }
}