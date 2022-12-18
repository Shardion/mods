using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Shardion.Zephyros.Content.Balancing.Recipes.BalancingConditions;

namespace Shardion.Zephyros.Content.Balancing.Recipes
{
    public class MolotovCocktailRecipeBuff : ModSystem
    {
        public static Recipe MolotovCocktailRecipe;

        public override void AddRecipes()
        {
            // FIXME: simplify this so the mod builds
            MolotovCocktailRecipe = Main.recipe.Take(Recipe.numRecipes)
                .Where(recipe => recipe.HasIngredient(ItemID.Ale))
                .Where(recipe => recipe.HasIngredient(ItemID.PinkGel))
                .Where(recipe => recipe.HasIngredient(ItemID.Silk))
                .Where(recipe => recipe.HasIngredient(ItemID.Torch))
.FirstOrDefault(recipe => recipe.HasResult(ItemID.MolotovCocktail));

            if (MolotovCocktailRecipe != null)
            {
                if (!MolotovCocktailRecipe.HasCondition(IsMolotovCocktailRecipeBuffNotEnabled))
                {
                    _ = MolotovCocktailRecipe.AddCondition(IsMolotovCocktailRecipeBuffNotEnabled);
                }
            }

            _ = Recipe.Create(ItemID.MolotovCocktail, 5).AddCondition(IsMolotovCocktailRecipeBuffEnabled).AddIngredient(ItemID.Ale, 5).AddIngredient(ItemID.Gel, 5).AddIngredient(ItemID.Silk, 1).AddIngredient(ItemID.Torch, 1).Register();
        }

        public override void Unload()
        {
            MolotovCocktailRecipe = null;
        }
    }
}
