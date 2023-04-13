using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shardion.Zephyros.Common.TravelingMerchantBlockShop;

namespace Shardion.Zephyros.Content.TravelingMerchantBlockShop.Structural
{
    public class SoilBrickGroup : EvenSpreadBlockGroup
    {
        public override BlockGroupPool Pool => BlockGroupPool.Structural;

        public override Item[] OnLoadItems(Mod mod)
        {
            return new Item[]
            {
                DefaultItem(ItemID.SandstoneBrick),
                DefaultItem(ItemID.RedBrick),
                DefaultItem(ItemID.SnowBrick),
                DefaultItem(ItemID.MudstoneBlock),
                DefaultItem(ItemID.IridescentBrick),
            };
        }
    }
}