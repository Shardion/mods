using Shardion.Zephyros.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content.VV.Items.Weapons.Sophisticated
{
    public class ShardScythe : ShardItem
    {
        public override bool UsePlaceholderSprite => true;

        public override void SetStaticDefaults()
        {
            // removed for calamity fandom wiki ver. because it doesn't fit
            // i guess this makes the weapon - in an extremely roundabout way - a reference to a game

            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 1000;
            Item.height = 1000;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.damage = 2222;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.channel = false;
            Developer = (int)DevIndex.Shardion;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanRightClick()
        {
            return true;
        }
    }
}
