using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shardion.Zephyros.Common.TravelingMerchantBlockShop;

namespace Shardion.Zephyros.Content.TravelingMerchantBlockShop.Structural
{
    public class WoodGroup : EvenSpreadBlockGroup
    {
        public override BlockGroupPool Pool => BlockGroupPool.Structural;

        public override Item[] OnLoadItems(Mod mod)
        {
            return new Item[]
            {
                DefaultItem(ItemID.Wood),
                DefaultItem(ItemID.BorealWood),
                DefaultItem(ItemID.RichMahogany),
                DefaultItem(ItemID.PalmWood),
                DefaultItem(ItemID.Ebonwood),
                DefaultItem(ItemID.Shadewood),
                DefaultItem(ItemID.AshWood),
                DefaultItem(ItemID.Pearlwood),
                DefaultItem(ItemID.DynastyWood),
            };
        }
    }
}