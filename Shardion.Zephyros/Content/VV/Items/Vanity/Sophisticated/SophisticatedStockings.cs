using Shardion.Zephyros.Utilities;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content.VV.Items.Vanity.Sophisticated
{
    [AutoloadEquip(EquipType.Legs)]
    public class SophisticatedStockings : ShardItem
    {
        public override void SetDefaults()
        {
            FemaleLegsTexture = "SophisticatedStockings_FemaleLegs";
            Developer = (int)DevIndex.Shardion;
            Item.width = 22;
            Item.height = 30;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.vanity = true;
            Item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            _ = CreateRecipe()
                .AddCondition(Recipes.VVConditions.AreThreadRecipesEnabled)
                .AddIngredient(Mod, "Fabric", 3)
                .AddIngredient(Mod, "WhiteThread", 1)
                .AddTile(TileID.Loom)
                .Register();

            _ = CreateRecipe()
                .AddCondition(Recipes.VVConditions.AreDyeRecipesEnabled)
                .AddIngredient(Mod, "Fabric", 3)
                .AddIngredient(ItemID.BrightSilverDye, 1)
                .AddTile(TileID.Loom)
                .Register();

            _ = CreateRecipe()
                .AddCondition(Recipes.VVConditions.AreNoColorRecipesEnabled)
                .AddIngredient(Mod, "Fabric", 3)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
    // long ago, there were variants of this item
    // now, they only live as layers in the krita files, doomed to eternal obscurity
}
