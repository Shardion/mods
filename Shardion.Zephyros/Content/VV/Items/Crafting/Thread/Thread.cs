using Shardion.Zephyros.Utilities;
using Terraria.ID;

namespace Shardion.Zephyros.Content.VV.Items.Crafting.Thread
{
    public class WhiteThread : ShardItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 20;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            _ = CreateRecipe(2)
                .AddCondition(Recipes.VVConditions.IsVVEnabled)
                .AddRecipeGroup("Wood", 1)
                .AddIngredient(ItemID.Cobweb, 4)
                .AddTile(TileID.Loom)
                .Register();
        }

        public void AddThreadRecipes(int dye)
        {
            _ = CreateRecipe(3)
                .AddIngredient(dye, 1)
                .AddIngredient(Mod, "WhiteThread", 3)
                .AddTile(TileID.Loom)
                .Register();

            _ = CreateRecipe(6)
                .AddIngredient(dye, 1)
                .AddIngredient(Mod, "WhiteThread", 6)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
    public class RedThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.RedDye); } }
    public class OrangeThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.OrangeDye); } }
    public class YellowThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.YellowDye); } }
    public class LimeThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.LimeDye); } }
    // has vanilla thread //public class GreenThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.GreenDye, this); } }
    public class TealThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.TealDye); } }
    public class CyanThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.CyanDye); } }
    public class SkyBlueThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.SkyBlueDye); } }
    public class BlueThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.BlueDye); } }
    public class PurpleThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.PurpleDye); } }
    public class VioletThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.VioletDye); } }
    // has vanilla thread //public class PinkThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.PinkDye, this); } }
    // has vanilla thread //public class BlackThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.BlackDye, this); } }
    public class BrownThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.BrownDye); } }
    public class SilverThread : WhiteThread { public override void AddRecipes() { AddThreadRecipes(ItemID.SilverDye); } }
}
