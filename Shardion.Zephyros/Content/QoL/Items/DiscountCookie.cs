using Microsoft.Xna.Framework;
using Shardion.Zephyros.Utilities;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using static Shardion.Zephyros.Content.QoL.Recipes.QoLConditions;

namespace Shardion.Zephyros.Content.QoL.Items
{
    public class DiscountCookie : ShardItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Eat to permanently gain the Discount Card effect\nDoes not stack with the Discount Card");
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(81, 121, 194),
                new Color(59, 63, 77),
                new Color(175, 215, 211)
            };
            ItemID.Sets.IsFood[Type] = true; //This allows it to be placed on a plate and held correctly
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(22, 22, BuffID.WellFed, 0);
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.maxStack = 1;
        }

        public override bool ConsumeItem(Player player)
        {
            player.GetModPlayer<QoLPlayer>().DiscountCookie = true;
            return true;
        }

        public override void AddRecipes()
        {
            _ = CreateRecipe()
                .AddCondition(IsDiscountCookieEnabled)
                .AddIngredient(ItemID.DiscountCard)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
