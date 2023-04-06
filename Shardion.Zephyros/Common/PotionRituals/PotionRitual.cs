using System;
using Terraria;
using Shardion.Zephyros.Common.Utilities;

namespace Shardion.Zephyros.Common.PotionRituals
{
    public enum PotionRitualDurationMode
    {
        Infinite,
        Static,
        MultipleOfBuff
    }

    public enum PotionRitualActivityMode
    {
        BossAlive,
        BossNotAlive
    }

    /// <summary>
    /// A potion ritual grants a player a given buff for an extended period of time, but only under certain circumstances.
    /// </summary>
    /// <remarks>
    /// Potion rituals only support vanilla buffs, to avoid compatibility issues.
    /// </remarks>
    public class PotionRitual : BuffManager
    {
        /// <summary>When the buff specified by this potion ritual should be granted.</summary>
        public PotionRitualActivityMode ActivityMode { get; set; }

        public PotionRitual(int buffType, Timer duration, PotionRitualActivityMode activityMode, Player player) : base(buffType, duration, player)
        {
            ActivityMode = activityMode;
        }

        public override bool PreUpdate()
        {
            return (ActivityMode == PotionRitualActivityMode.BossAlive && GameState.BossAlive) || (ActivityMode == PotionRitualActivityMode.BossNotAlive && !GameState.BossAlive);
        }

        public override string OnSerialize(string serializedManagedBuff)
        {
            return $"{base.OnSerialize(serializedManagedBuff)},{ActivityMode}";
        }

        public override void OnDeserialize(string[] serializedManagedBuffParts)
        {
            ActivityMode = PotionRitualActivityMode.BossAlive;
            if (Enum.TryParse(serializedManagedBuffParts[2], out PotionRitualActivityMode activityMode))
            {
                ActivityMode = activityMode;
            }
        }

        public override void OnDeserializeException()
        {
            ActivityMode = PotionRitualActivityMode.BossAlive;
        }
    }
}
