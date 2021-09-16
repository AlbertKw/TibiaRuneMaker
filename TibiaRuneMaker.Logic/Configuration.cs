using System;
using TibiaRuneMaker.Logic.Enums;
using TibiaRuneMaker.Logic.Models;

namespace TibiaRuneMaker.Logic
{
    public class Configuration
    {
        public readonly UserConfigurationModel UserConfiguration;
        public string ClientProcessName => "client";
        
        #region Keys
        
        public KeysEnum KeySpellCast = KeysEnum.F1;
        public KeysEnum KeyEatFood = KeysEnum.F2;
        public KeysEnum KeyEquipLifeRing = KeysEnum.F3;
        public KeysEnum KeyEquipSoftBoots = KeysEnum.F4;

        #endregion

        public Configuration(UserConfigurationModel userConfiguration)
        {
            UserConfiguration = userConfiguration;
        }
    }
}