using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shardion.Zephyros.Common.TravelingMerchantBlockShop;

namespace Shardion.Zephyros.Content.TravelingMerchantBlockShop.Structural
{
    public class AlternativeOreBrickGroup : EvenSpreadBlockGroup
    {
        public override BlockGroupPool Pool => BlockGroupPool.Structural;

        public override Item[] OnLoadItems(Mod mod)
        {
            return new Item[]
            {
                DefaultItem(ItemID.TinBrick),
                DefaultItem(ItemID.LeadBrick),
                DefaultItem(ItemID.TungstenBrick),
                DefaultItem(ItemID.PlatinumBrick),
            };
        }
    }
}