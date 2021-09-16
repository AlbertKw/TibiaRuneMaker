using System;
using TibiaRuneMaker.Logic.Enums;

namespace TibiaRuneMaker.Logic
{
    public class Configuration
    {
        public string ClientProcessName => "client";
        
        #region Cooldowns

        public short CastSpellCooldown => 40;
        public short EatFoodCooldown => 10 * 60;
        public short SoftBootsCooldown => 4 * 60 * 60;
        public short LifeRingCooldown => 20 * 60;

        #endregion

        #region RandomizeCooldownValues
        public short EatFoodMinimumRandomTime => 30;
        public short EatFoodMaximumRandomTime => 1 * 60;
        public short CastSpellMinimumRandomTime => 2;
        public short CastSpellMaximumRandomTime => 7;
        public short LifeRingMinimumRandomTime => 10;
        public short LifeRingMaximumRandomTime => 30;
        public short SoftBootsMinimumRandomTime => 10;
        public short SoftBootsMaximumRandomTime => 20 + 1 * 60;

        #endregion

        #region Keys

        public KeysEnum KeySpellCast = KeysEnum.F1;
        public KeysEnum KeyEatFood = KeysEnum.F2;
        public KeysEnum KeyEquipLifeRing = KeysEnum.F3;
        public KeysEnum KeyEquipSoftBoots = KeysEnum.F4;

        #endregion
    }
}