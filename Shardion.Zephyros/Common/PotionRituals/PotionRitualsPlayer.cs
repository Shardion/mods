using System.Collections.Generic;
using Terraria.ModLoader;
using Shardion.Zephyros.Common.Utilities;

namespace Shardion.Zephyros.Common.PotionRituals
{
    public class BuffManagerPlayer : ModPlayer
    {
        public List<BuffManager> BuffManagers { get; set; } = new();

        /// <summary>
        /// Adds <paramref name="manager"/> to the player's active buff managers.
        /// If the player already has a buff manager with <paramref name="manager"/>'s buff type,
        /// this method returns false, and <paramref name="manager"/>'s duration is added to the old one.
        /// </summary>
        public bool AddBuffManager(BuffManager manager)
        {
            foreach (BuffManager currentManager in BuffManagers)
            {
                if (currentManager.Type == manager.Type)
                {
                    currentManager.Duration.Ticks += manager.Duration.Ticks;
                    return false;
                }
            }
            BuffManagers.Add(manager);
            return true;
        }

        public override void PreUpdateBuffs()
        {
            base.PreUpdateBuffs();
            foreach (BuffManager manager in BuffManagers)
            {
                if (manager.Duration.Ticks > 0)
                {
                    manager.Update();
                }
                else
                {
                    BuffManagers.Remove(manager);
                }
            }
        }
    }
}