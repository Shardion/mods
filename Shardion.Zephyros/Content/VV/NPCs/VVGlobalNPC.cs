using System.Linq;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content.VV.NPCs
{
    public class VVGlobalNPC : GlobalNPC
    {
        private readonly int[] planterBoxes = {
            ItemID.CorruptPlanterBox,
            ItemID.CrimsonPlanterBox,
            ItemID.DayBloomPlanterBox,
            ItemID.MoonglowPlanterBox,
            ItemID.BlinkrootPlanterBox,
            ItemID.WaterleafPlanterBox,
            ItemID.FireBlossomPlanterBox,
            ItemID.ShiverthornPlanterBox
        };
        public override bool InstancePerEntity => true;
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Dryad && ModContent.GetInstance<Utilities.VariousVanitiesConfig>().AlwaysSellPlanterBoxes)
            {
                int[] ignore = Array.Empty<int>();
                foreach (Item item in shop.item)
                {
                    if (planterBoxes.Contains(item.type))
                    {
                        ignore = ignore.Append(item.type).ToArray();
                    }
                }
                foreach (int item in planterBoxes)
                {
                    if (!ignore.Contains(item))
                    {
                        bool corruptAndShouldIgnoreCrimson = item == ItemID.CorruptPlanterBox && ignore.Contains(ItemID.CrimsonPlanterBox);
                        bool crimsonAndShouldIgnoreCorrupt = item == ItemID.CrimsonPlanterBox && ignore.Contains(ItemID.CorruptPlanterBox);
                        if (!(corruptAndShouldIgnoreCrimson || crimsonAndShouldIgnoreCorrupt))
                        {
                            shop.item[nextSlot].SetDefaults(item);
                            nextSlot++;
                        }
                    }
                }
            }
        }
    }
}
