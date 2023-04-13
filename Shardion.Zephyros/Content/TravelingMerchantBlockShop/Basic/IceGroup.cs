using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shardion.Zephyros.Common.TravelingMerchantBlockShop;

namespace Shardion.Zephyros.Content.TravelingMerchantBlockShop.Basic
{
    public class IceGroup : EvenSpreadBlockGroup
    {
        public override BlockGroupPool Pool => BlockGroupPool.Basic;

        public override Item[] OnLoadItems(Mod mod)
        {
            return new Item[] { DefaultItem(ItemID.IceBlock) };
        }
    }
}