using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content.QoL.NPCs
{
    public class QoLGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        private readonly int[] mushroomEnemies = {
            NPCID.SporeBat,
            NPCID.SporeSkeleton,
            NPCID.ZombieMushroom,
            NPCID.ZombieMushroomHat,
            NPCID.MushiLadybug,
            NPCID.FungiBulb,
            NPCID.FungoFish,
            NPCID.AnomuraFungus,
            NPCID.GiantFungiBulb
        };
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (mushroomEnemies.Contains(npc.type) && ModContent.GetInstance<Utilities.QoLConfig>().MushroomEnemiesDropSeeds)
            {
                _ = npcLoot.Add(ItemDropRule.Common(ItemID.MushroomGrassSeeds, 10));
            }
            if ((npc.type == NPCID.TruffleWorm || npc.type == NPCID.TruffleWormDigger) && ModContent.GetInstance<Utilities.QoLConfig>().MushroomEnemiesDropSeeds)
            {
                _ = npcLoot.Add(ItemDropRule.Common(ItemID.MushroomGrassSeeds, 100, 2, 2));
            }
            base.ModifyNPCLoot(npc, npcLoot);
        }
    }
}
