using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Common.TravelingMerchantBlockShop
{
    public class TravelingMerchantBlockShopGlobalNPC : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.TravellingMerchant;
        }

        public override void ModifyActiveShop(NPC npc, string shopName, Item?[] items)
        {
            int nextShopItemIndex = items.GetLowerBound(0);
            int maxShopItemIndex = items.GetUpperBound(0);

            for (int index = nextShopItemIndex; index < maxShopItemIndex; index++)
            {
                if (items[index]?.type > 0)
                {
                    nextShopItemIndex++;
                }
            }

            foreach (Item item in TravelingMerchantBlockShopSystem.BlockShopContents)
            {
                items[nextShopItemIndex] = item.Clone();
                nextShopItemIndex++;
            }
        }
    }
}