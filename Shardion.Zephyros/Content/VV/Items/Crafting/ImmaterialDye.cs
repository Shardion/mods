using Shardion.Zephyros.Utilities;
using Terraria;
using Terraria.ID;

namespace Shardion.Zephyros.Content.VV.Items.Crafting
{
    public class ImmaterialDye : ShardItem
    {
        public override void SetDefaults()
        {
            //UsePlaceholderSprite = true;
            Item.width = 22;
            Item.height = 32;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            _ = CreateRecipe()
                .AddCondition(Recipes.VVConditions.IsVVEnabled)
                .AddRecipeGroup("VariousVanities:DyeSources", 3)
                .AddTile(TileID.DyeVat)
                .Register();

            int[] dyes = new int[]
            {
                ItemID.RedDye,
                ItemID.OrangeDye,
                ItemID.YellowDye,
                ItemID.LimeDye,
                ItemID.GreenDye,
                ItemID.TealDye,
                ItemID.CyanDye,
                ItemID.SkyBlueDye,
                ItemID.BlueDye,
                ItemID.PurpleDye,
                ItemID.VioletDye,
                ItemID.PinkDye,
                ItemID.BlackDye,
                ItemID.BrownDye,
                ItemID.SilverDye
            };

            foreach (int dye in dyes)
            {
                _ = Recipe.Create(dye)
                    .AddCondition(Recipes.VVConditions.IsVVEnabled)
                    .AddIngredient(this, 1)
                    .AddTile(TileID.DyeVat)
                    .Register();
            }
        }
    }
}
