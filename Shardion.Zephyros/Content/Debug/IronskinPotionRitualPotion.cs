using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shardion.Zephyros.Common.PotionRituals;
using Shardion.Zephyros.Common.Utilities;

namespace Shardion.Zephyros.Content.Debug
{
    public class IronskinPotionRitualPotion : ModItem
    {
        public override string Texture => "Terraria/Images/Item_292";

        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 60;
        }

        public override bool CanUseItem(Player player)
        {
            base.OnConsumeItem(player);
            player.GetModPlayer<BuffManagerPlayer>().AddBuffManager(new PotionRitual(BuffID.Ironskin, new Timer() { Minutes = 1 }, PotionRitualActivityMode.BossNotAlive, player));
            player.GetModPlayer<BuffManagerPlayer>().AddBuffManager(new BuffManager(BuffID.Lifeforce, new Timer() { Minutes = 1 }, player));
            return true;
        }
    }
}