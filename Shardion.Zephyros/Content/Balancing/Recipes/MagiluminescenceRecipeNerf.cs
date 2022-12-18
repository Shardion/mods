using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Shardion.Zephyros.Content.Balancing.Recipes.BalancingConditions;

namespace Shardion.Zephyros.Content.Balancing.Recipes
{
    public class MagiluminescenceRecipeNerf : ModSystem
    {
        public static Recipe MagiluminescenceCorruptionRecipe;
        public static Recipe MagiluminescenceCrimsonRecipe;

        public override void AddRecipes()
        {
            // FIXME: simplify this so the mod builds
            MagiluminescenceCorruptionRecipe = Main.recipe.Take(Recipe.numRecipes)
                .Where(recipe => recipe.HasIngredient(ItemID.Topaz))
                .Where(recipe => recipe.HasIngredient(ItemID.DemoniteBar))
                .Where(recipe => recipe.HasTile(TileID.Anvils))
.FirstOrDefault(recipe => recipe.HasResult(ItemID.Magiluminescence));

            if (MagiluminescenceCorruptionRecipe != null)
            {
                if (!MagiluminescenceCorruptionRecipe.HasCondition(IsMagiluminescenceRecipeNerfNotEnabled))
                {
                    _ = MagiluminescenceCorruptionRecipe.AddCondition(IsMagiluminescenceRecipeNerfNotEnabled);
                }
            }

            // FIXME: simplify this so the mod builds
            MagiluminescenceCrimsonRecipe = Main.recipe.Take(Recipe.numRecipes)
                .Where(recipe => recipe.HasIngredient(ItemID.Topaz))
                .Where(recipe => recipe.HasIngredient(ItemID.CrimtaneBar))
                .Where(recipe => recipe.HasTile(TileID.Anvils))
.FirstOrDefault(recipe => recipe.HasResult(ItemID.Magiluminescence));

            if (MagiluminescenceCrimsonRecipe != null)
            {
                if (!MagiluminescenceCrimsonRecipe.HasCondition(IsMagiluminescenceRecipeNerfNotEnabled))
                {
                    _ = MagiluminescenceCrimsonRecipe.AddCondition(IsMagiluminescenceRecipeNerfNotEnabled);
                }
            }

            _ = Recipe.Create(ItemID.Magiluminescence).AddCondition(IsMagiluminescenceRecipeNerfEnabled).AddIngredient(ItemID.Topaz, 5).AddIngredient(ItemID.DemoniteBar, 12).AddIngredient(ItemID.ShadowScale, 4).AddTile(TileID.Anvils).Register();
            _ = Recipe.Create(ItemID.Magiluminescence).AddCondition(IsMagiluminescenceRecipeNerfEnabled).AddIngredient(ItemID.Topaz, 5).AddIngredient(ItemID.CrimtaneBar, 12).AddIngredient(ItemID.TissueSample, 4).AddTile(TileID.Anvils).Register();
        }

        public override void Unload()
        {
            MagiluminescenceCorruptionRecipe = null;
            MagiluminescenceCrimsonRecipe = null;
        }
    }
}
