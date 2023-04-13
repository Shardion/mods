using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shardion.Zephyros.Common.TravelingMerchantBlockShop;

namespace Shardion.Zephyros.Content.TravelingMerchantBlockShop.Structural
{
    public class PrimaryOreBrickGroup : EvenSpreadBlockGroup
    {
        public override BlockGroupPool Pool => BlockGroupPool.Structural;

        public override Item[] OnLoadItems(Mod mod)
        {
            return new Item[]
            {
                DefaultItem(ItemID.CopperBrick),
                DefaultItem(ItemID.IronBrick),
                DefaultItem(ItemID.SilverBrick),
                DefaultItem(ItemID.GoldBrick),
            };
        }
    }
}