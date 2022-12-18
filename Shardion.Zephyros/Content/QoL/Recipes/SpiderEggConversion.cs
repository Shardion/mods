using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Shardion.Zephyros.Content.QoL.Recipes.QoLConditions;

namespace Shardion.Zephyros.Content.QoL.Recipes
{
    public class SpiderEggConversion : ModSystem
    {
        public override void AddRecipes()
        {
            int[] pumpkingDrops = {
                ItemID.RavenStaff,
                ItemID.BatScepter,
                ItemID.JackOLanternLauncher,
                ItemID.ScytheWhip,
                ItemID.CandyCornRifle,
                ItemID.TheHorsemansBlade,
                ItemID.BlackFairyDust
            };

            foreach (int drop in pumpkingDrops)
            {
                _ = Recipe.Create(drop)
                    .AddCondition(IsMoonDropConversionEnabled)
                    .AddIngredient(ItemID.SpiderEgg)
                    .AddTile(TileID.CrystalBall)
                    .Register();
            }
        }
    }
}
