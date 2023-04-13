using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shardion.Zephyros.Common.TravelingMerchantBlockShop;

namespace Shardion.Zephyros.Content.TravelingMerchantBlockShop.Structural
{
    public class StoneBrickGroup : EvenSpreadBlockGroup
    {
        public override BlockGroupPool Pool => BlockGroupPool.Structural;

        public override Item[] OnLoadItems(Mod mod)
        {
            return new Item[]
            {
                DefaultItem(ItemID.GrayBrick),
                DefaultItem(ItemID.IceBrick),
                DefaultItem(ItemID.EbonstoneBrick),
                DefaultItem(ItemID.CrimstoneBrick),
                DefaultItem(ItemID.StoneSlab),
            };
        }
    }
}