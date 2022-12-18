using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.Recipe;

namespace Shardion.Zephyros.Content.QoL.Recipes
{
    public class QoLConditions : ModSystem
    {
        public static readonly Condition IsQoLEnabled = new(NetworkText.FromKey("RecipeConditions.IsQoLEnabled"), _ => ModContent.GetInstance<Utilities.QoLConfig>().QoLModuleEnabled);
        public static readonly Condition IsQoLNotEnabled = new(NetworkText.FromKey("RecipeConditions.IsQoLNotEnabled"), _ => !ModContent.GetInstance<Utilities.QoLConfig>().QoLModuleEnabled);
        public static readonly Condition IsCrateCraftingEnabled = new(NetworkText.FromKey("RecipeConditions.IsCrateCraftingEnabled"), _ => ModContent.GetInstance<Utilities.QoLConfig>().QoLModuleEnabled && ModContent.GetInstance<Utilities.QoLConfig>().CrateCrafting);
        public static readonly Condition IsGemCraftingEnabled = new(NetworkText.FromKey("RecipeConditions.IsGemCraftingEnabled"), _ => ModContent.GetInstance<Utilities.QoLConfig>().QoLModuleEnabled && ModContent.GetInstance<Utilities.QoLConfig>().GemCrafting);
        public static readonly Condition IsDiscountCookieEnabled = new(NetworkText.FromKey("RecipeConditions.IsDiscountCookieEnabled"), _ => ModContent.GetInstance<Utilities.QoLConfig>().DiscountCookie);
        public static readonly Condition IsChlorophyteBarRecipeBuffEnabled = new(NetworkText.FromKey("RecipeConditions.IsChlorophyteBarRecipeBuffEnabled"), _ => ModContent.GetInstance<Utilities.QoLConfig>().ChlorophyteBarRecipeBuff);
        public static readonly Condition IsChlorophyteBarRecipeBuffNotEnabled = new(NetworkText.FromKey("RecipeConditions.IsChlorophyteBarRecipeBuffNotEnabled"), _ => !ModContent.GetInstance<Utilities.QoLConfig>().ChlorophyteBarRecipeBuff);
        public static readonly Condition IsMoonDropConversionEnabled = new(NetworkText.FromKey("RecipeConditions.IsMoonDropConversionEnabled"), _ => ModContent.GetInstance<Utilities.QoLConfig>().MoonDropConversion);
    }
}
