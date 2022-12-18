using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Shardion.Zephyros.Content.QoL.Recipes.QoLConditions;

namespace Shardion.Zephyros.Content.QoL.Recipes
{
    public class GemCrafting : ModSystem
    {
        public override void AddRecipes()
        {
            int[] gems = {
                ItemID.Topaz,
                ItemID.Amethyst,
                ItemID.Ruby,
                ItemID.Sapphire,
                ItemID.Emerald,
                ItemID.Amber
            };
            foreach (int gem in gems)
            {
                _ = Recipe.Create(ItemID.Diamond)
                    .AddCondition(IsGemCraftingEnabled)
                    .AddIngredient(gem)
                    .AddTile(TileID.DemonAltar)
                    .Register();
                _ = Recipe.Create(gem)
                    .AddCondition(IsGemCraftingEnabled)
                    .AddIngredient(ItemID.Diamond)
                    .AddTile(TileID.DemonAltar)
                    .Register();
            }
        }
    }
}
