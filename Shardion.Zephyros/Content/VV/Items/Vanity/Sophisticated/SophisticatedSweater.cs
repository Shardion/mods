using Shardion.Zephyros.Utilities;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content.VV.Items.Vanity.Sophisticated
{
    [AutoloadEquip(EquipType.Body)]
    public class SophisticatedSweater : ShardItem
    {
        public override void SetStaticDefaults()
        {
            int bodySlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
            ArmorIDs.Body.Sets.HidesHands[bodySlot] = false;
        }

        public override void SetDefaults()
        {

            Developer = (int)DevIndex.Shardion;
            Item.width = 30;
            Item.height = 20;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.vanity = true;
            Item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            _ = CreateRecipe()
                .AddCondition(Recipes.VVConditions.AreThreadRecipesEnabled)
                .AddIngredient(Mod, "Fabric", 4)
                .AddIngredient(ItemID.BlackThread, 3)
                .AddTile(TileID.Loom)
                .Register();

            _ = CreateRecipe()
                .AddCondition(Recipes.VVConditions.AreDyeRecipesEnabled)
                .AddIngredient(Mod, "Fabric", 4)
                .AddIngredient(ItemID.BlackDye, 1)
                .AddTile(TileID.Loom)
                .Register();

            _ = CreateRecipe()
                .AddCondition(Recipes.VVConditions.AreNoColorRecipesEnabled)
                .AddIngredient(Mod, "Fabric", 4)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
