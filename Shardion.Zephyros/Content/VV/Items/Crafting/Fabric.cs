using Shardion.Zephyros.Utilities;
using Terraria.ID;

namespace Shardion.Zephyros.Content.VV.Items.Crafting
{
    public class Fabric : ShardItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'The cooler loader'");
        }

        public override void SetDefaults()
        {
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
                .AddIngredient(ItemID.Cobweb, 12)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
