using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content
{
    public class ShardRecipeGroups : ModSystem
    {
        public static RecipeGroup StrangeDyes;
        public static RecipeGroup DyeSources;

        public override void AddRecipeGroups()
        {
            StrangeDyes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Strange Dye", new int[]
            {
                ItemID.AcidDye,
                ItemID.BlueAcidDye,
                ItemID.RedAcidDye,
                ItemID.ChlorophyteDye,
                ItemID.GelDye,
                ItemID.MushroomDye, // Glowing Mushroom Dye
                ItemID.GrimDye,
                ItemID.HadesDye,
                ItemID.BurningHadesDye,
                ItemID.ShadowflameHadesDye,
                ItemID.LivingOceanDye,
                ItemID.LivingFlameDye,
                ItemID.LivingRainbowDye,
                ItemID.MartianArmorDye, // Martian Dye
                ItemID.MidnightRainbowDye,
                ItemID.MirageDye,
                ItemID.NegativeDye,
                ItemID.PixieDye,
                ItemID.PhaseDye,
                ItemID.PurpleOozeDye,
                ItemID.ReflectiveDye,
                ItemID.ReflectiveCopperDye,
                ItemID.ReflectiveGoldDye,
                ItemID.ReflectiveObsidianDye,
                ItemID.ReflectiveMetalDye,
                ItemID.ReflectiveSilverDye,
                ItemID.ShadowDye,
                ItemID.ShiftingSandsDye,
                ItemID.DevDye, // Skiphs' Blood
                ItemID.TwilightDye,
                ItemID.WispDye,
                ItemID.InfernalWispDye,
                ItemID.UnicornWispDye
            });

            _ = RecipeGroup.RegisterGroup("VariousVanities:StrangeDyes", StrangeDyes);
            DyeSources = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Dye Source", new int[]
            {
                ItemID.RedHusk,
                ItemID.OrangeBloodroot,
                ItemID.YellowMarigold,
                ItemID.LimeKelp,
                ItemID.GreenMushroom,
                ItemID.TealMushroom,
                ItemID.CyanHusk,
                ItemID.SkyBlueFlower,
                ItemID.BlueBerries,
                ItemID.PurpleMucos,
                ItemID.VioletHusk,
                ItemID.PinkPricklyPear,
                ItemID.BlackInk
            });
            _ = RecipeGroup.RegisterGroup("VariousVanities:DyeSources", DyeSources);
        }

        public override void Unload()
        {
            StrangeDyes = null;
            DyeSources = null;
        }
    }
}
