using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content.Balancing.Items
{
    public class BalancingGloalItem : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (ModContent.GetInstance<Utilities.BalancingConfig>().SwapSoaringInsignia)
            {
                if (item.type == ItemID.FairyQueenBossBag)
                {
                    itemLoot.RemoveWhere(
                        rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.EmpressFlightBooster
                    );
                    _ = itemLoot.Add(ItemDropRule.Common(ItemID.GravityGlobe, 1));
                }
                else if (item.type == ItemID.MoonLordBossBag)
                {
                    itemLoot.RemoveWhere(
                        rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.GravityGlobe
                    );
                    _ = itemLoot.Add(ItemDropRule.Common(ItemID.EmpressFlightBooster, 1));
                }
            }
        }
    }
}
