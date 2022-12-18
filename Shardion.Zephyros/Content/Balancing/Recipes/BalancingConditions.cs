using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.Recipe;

namespace Shardion.Zephyros.Content.Balancing.Recipes
{
    public class BalancingConditions : ModSystem
    {
        public static readonly Condition IsBalancingEnabled = new(NetworkText.FromKey("RecipeConditions.IsBalancingEnabled"), _ => ModContent.GetInstance<Utilities.BalancingConfig>().BalancingModuleEnabled);
        public static readonly Condition IsBalancingNotEnabled = new(NetworkText.FromKey("RecipeConditions.IsBalancingNotEnabled"), _ => !ModContent.GetInstance<Utilities.BalancingConfig>().BalancingModuleEnabled);
        public static readonly Condition IsMolotovCocktailRecipeBuffEnabled = new(NetworkText.FromKey("RecipeConditions.IsMolotovCocktailRecipeBuffEnabled"), _ => ModContent.GetInstance<Utilities.BalancingConfig>().MolotovRecipeBuff);
        public static readonly Condition IsMolotovCocktailRecipeBuffNotEnabled = new(NetworkText.FromKey("RecipeConditions.IsMolotovCocktailRecipeBuffNotEnabled"), _ => !ModContent.GetInstance<Utilities.BalancingConfig>().MolotovRecipeBuff);
        public static readonly Condition IsMagiluminescenceRecipeNerfEnabled = new(NetworkText.FromKey("RecipeConditions.IsMagiluminescenceRecipeNerfEnabled"), _ => ModContent.GetInstance<Utilities.BalancingConfig>().MagiluminescenceRecipeNerf);
        public static readonly Condition IsMagiluminescenceRecipeNerfNotEnabled = new(NetworkText.FromKey("RecipeConditions.IsMagiluminescenceRecipeNerfNotEnabled"), _ => !ModContent.GetInstance<Utilities.BalancingConfig>().MagiluminescenceRecipeNerf);
        public static readonly Condition IsTerrasparkBootsRecipeNerfEnabled = new(NetworkText.FromKey("RecipeConditions.IsTerrasparkBootsRecipeNerfEnabled"), _ => ModContent.GetInstance<Utilities.BalancingConfig>().TerrasparkBootsRecipeNerf);
        public static readonly Condition IsTerrasparkBootsRecipeNerfNotEnabled = new(NetworkText.FromKey("RecipeConditions.IsTerrasparkBootsRecipeNerfNotEnabled"), _ => !ModContent.GetInstance<Utilities.BalancingConfig>().TerrasparkBootsRecipeNerf);
    }
}
