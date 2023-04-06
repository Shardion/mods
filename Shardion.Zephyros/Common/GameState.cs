using Terraria;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Common.Utilities
{
    public static class GameState
    {
        /// <summary>If a boss is alive.</summary>
        public static bool BossAlive { get; set; }
    }

    /// <summary>Responsible for updating the variables in <c>GameState</c>.</summary>
    public class GameStateChecker : ModSystem
    {
        public override void PreUpdateNPCs()
        {
            base.PreUpdateNPCs();
            GameState.BossAlive = false;
            foreach (NPC npc in Main.npc)
            {
                if (npc.boss)
                {
                    GameState.BossAlive = true;
                    return;
                }
            }
        }
    }
}
