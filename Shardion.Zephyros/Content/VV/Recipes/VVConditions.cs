using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.Recipe;

namespace Shardion.Zephyros.Content.VV.Recipes
{
    public class VVConditions : ModSystem
    {
        public static readonly Condition IsVVEnabled = new(NetworkText.FromKey("RecipeConditions.IsVVNotEnabled"), _ => ModContent.GetInstance<Utilities.VariousVanitiesConfig>().VariousVanitiesEnabled);
        public static readonly Condition IsVVNotEnabled = new(NetworkText.FromKey("RecipeConditions.IsVVEnabled"), _ => !ModContent.GetInstance<Utilities.VariousVanitiesConfig>().VariousVanitiesEnabled);

        public static readonly Condition AreThreadRecipesEnabled = new(NetworkText.FromKey("RecipeConditions.AreThreadRecipesEnabled"), _ => ModContent.GetInstance<Utilities.VariousVanitiesConfig>().DoDyedThreads && ModContent.GetInstance<Utilities.VariousVanitiesConfig>().VariousVanitiesEnabled);
        public static readonly Condition AreDyeRecipesEnabled = new(NetworkText.FromKey("RecipeConditions.AreDyeRecipesEnabled"), _ => ModContent.GetInstance<Utilities.VariousVanitiesConfig>().DoDyes && ModContent.GetInstance<Utilities.VariousVanitiesConfig>().VariousVanitiesEnabled);
        public static readonly Condition AreNoColorRecipesEnabled = new(NetworkText.FromKey("RecipeConditions.AreNoColorRecipesEnabled"), _ => ModContent.GetInstance<Utilities.VariousVanitiesConfig>().DoNone && ModContent.GetInstance<Utilities.VariousVanitiesConfig>().VariousVanitiesEnabled);

        public static readonly Condition IsPreBossFamiliarSetEnabled = new(NetworkText.FromKey("RecipeConditions.IsPreBossFamiliarSetEnabled"), _ => ModContent.GetInstance<Utilities.VariousVanitiesConfig>().PreBossFamiliarSet && ModContent.GetInstance<Utilities.VariousVanitiesConfig>().VariousVanitiesEnabled);
    }
}
