using Terraria.ModLoader;
using Terraria;

namespace Shardion.Ether.NPCs
{
    public class EtherGlobalNPC : GlobalNPC
    {
        public static int Oddity { get; set; } = -1;

        public static bool IsOddityAlive()
        {
            if (Oddity == -1)
            {
                return false;
            }
            if (Main.npc.GetValue(Oddity) is NPC npc)
            {
                if (npc.type == ModContent.GetInstance<Oddity.Oddity>().Type && npc.active)
                {
                    return true;
                }
            }
            Oddity = -1; // oddity isn't alive now
            return false;
        }
    }
}
