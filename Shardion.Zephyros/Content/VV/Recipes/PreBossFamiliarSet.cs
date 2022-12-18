using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Shardion.Zephyros.Content.VV.Recipes.VVConditions;

namespace Shardion.Zephyros.Content.VV.Recipes
{
    public class PreBossFamiliarSet : ModSystem
    {
        public override void AddRecipes()
        {
            _ = Recipe.Create(ItemID.FamiliarWig)
                .AddCondition(IsPreBossFamiliarSetEnabled)
                .AddIngredient(Mod, "Fabric", 2)
                .AddIngredient(ItemID.ManaCrystal)
                .AddTile(TileID.Loom)
                .Register();

            _ = Recipe.Create(ItemID.FamiliarShirt)
                .AddCondition(IsPreBossFamiliarSetEnabled)
                .AddIngredient(Mod, "Fabric", 4)
                .AddIngredient(ItemID.ManaCrystal)
                .AddTile(TileID.Loom)
                .Register();

            _ = Recipe.Create(ItemID.FamiliarPants)
                .AddCondition(IsPreBossFamiliarSetEnabled)
                .AddIngredient(Mod, "Fabric", 3)
                .AddIngredient(ItemID.ManaCrystal)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
