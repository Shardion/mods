using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Shardion.Zephyros.Content.Balancing.Recipes.BalancingConditions;

namespace Shardion.Zephyros.Content.Balancing.Recipes
{
    public class TerrasparkBootsRecipeNerf : ModSystem
    {
        public static Recipe TerrasparkBootsRecipe;

        public override void AddRecipes()
        {

            // FIXME: simplify this so the mod builds
            TerrasparkBootsRecipe = Main.recipe.Take(Recipe.numRecipes)
                .Where(recipe => recipe.HasIngredient(ItemID.FrostsparkBoots))
                .Where(recipe => recipe.HasIngredient(ItemID.LavaWaders))
                .Where(recipe => recipe.HasTile(TileID.TinkerersWorkbench))
.FirstOrDefault(recipe => recipe.HasResult(ItemID.TerrasparkBoots));

            if (TerrasparkBootsRecipe != null)
            {
                if (!TerrasparkBootsRecipe.HasCondition(IsTerrasparkBootsRecipeNerfNotEnabled))
                {
                    _ = TerrasparkBootsRecipe.AddCondition(IsTerrasparkBootsRecipeNerfNotEnabled);
                }
            }

            _ = Recipe.Create(ItemID.TerrasparkBoots)
                .AddCondition(IsTerrasparkBootsRecipeNerfEnabled)
                .AddIngredient(ItemID.FrostsparkBoots)
                .AddIngredient(ItemID.LavaWaders)
                .AddIngredient(ItemID.SoulofFright)
                .AddIngredient(ItemID.SoulofMight)
                .AddIngredient(ItemID.SoulofSight)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override void Unload()
        {
            TerrasparkBootsRecipe = null;
        }
    }
}
