namespace TibiaRuneMaker.Logic.Models
{
    public record UserConfigurationModel
    {
        public string ApiKey { get; init; }
        
        #region Cooldowns

        public short CastSpellCooldown { get; init; }
        public short EatFoodCooldown { get; init; }
        public short SoftBootsCooldown { get; init; }
        public short LifeRingCooldown { get; init; }

        #endregion

        #region RandomizeCooldownValues
        public short EatFoodMinimumRandomTime { get; init; }
        public short EatFoodMaximumRandomTime { get; init; }
        public short CastSpellMinimumRandomTime { get; init; }
        public short CastSpellMaximumRandomTime { get; init; }
        public short LifeRingMinimumRandomTime { get; init; }
        public short LifeRingMaximumRandomTime { get; init; }
        public short SoftBootsMinimumRandomTime { get; init; }
        public short SoftBootsMaximumRandomTime { get; init; }

        #endregion
    }
}