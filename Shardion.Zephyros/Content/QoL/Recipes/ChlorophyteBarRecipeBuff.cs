using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Shardion.Zephyros.Content.QoL.Recipes.QoLConditions;

namespace Shardion.Zephyros.Content.QoL.Recipes
{
    public class ChlorophyteBarRecipeBuff : ModSystem
    {
        public static Recipe ChlorophyteBarRecipe;

        public override void AddRecipes()
        {
            // FIXME: simplify this so the mod builds
            ChlorophyteBarRecipe = Main.recipe.Take(Recipe.numRecipes)
                .Where(recipe => recipe.HasIngredient(ItemID.ChlorophyteOre))
                .Where(recipe => recipe.HasTile(TileID.AdamantiteForge))
.FirstOrDefault(recipe => recipe.HasResult(ItemID.ChlorophyteBar));

            if (ChlorophyteBarRecipe != null)
            {
                if (!ChlorophyteBarRecipe.HasCondition(IsChlorophyteBarRecipeBuffNotEnabled))
                {
                    _ = ChlorophyteBarRecipe.AddCondition(IsChlorophyteBarRecipeBuffNotEnabled);
                }
            }

            _ = Recipe.Create(ItemID.ChlorophyteBar).AddCondition(IsChlorophyteBarRecipeBuffEnabled).AddIngredient(ItemID.ChlorophyteOre, 4).AddTile(TileID.AdamantiteForge).Register();
        }

        public override void Unload()
        {
            ChlorophyteBarRecipe = null;
        }
    }
}
