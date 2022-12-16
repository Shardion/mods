using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VsOddity.Items.Weapons
{
    public class UltimateTruth : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'The blade of blinding light from a defeated foe...'");
        }

        public override void SetDefaults()
        {
            Item.damage = 15000;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
    }
}
