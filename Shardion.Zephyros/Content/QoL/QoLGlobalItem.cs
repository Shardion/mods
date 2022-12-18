using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content.QoL
{
    public class QoLGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            int[] gems = {
                ItemID.Topaz,
                ItemID.Amethyst,
                ItemID.Ruby,
                ItemID.Sapphire,
                ItemID.Emerald,
                ItemID.Diamond,
                ItemID.Amber
            };
            if (gems.Contains(item.type) && ModContent.GetInstance<Utilities.QoLConfig>().GemCrafting)
            {
                item.value = Item.sellPrice(silver: 3, copper: 75);
            }
        }
    }
}
