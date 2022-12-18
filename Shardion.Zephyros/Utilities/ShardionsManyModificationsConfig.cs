using System.ComponentModel;
using Newtonsoft.Json;
using Terraria.ModLoader.Config;

namespace Shardion.Zephyros.Utilities
{
    public class ShardionsManyModificationsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [JsonIgnore]
        [Label("Looking for the configs for individual modules?")]
        public bool IExistPurelyToDisplayInfo;
        [JsonIgnore]
        [Label("Click the arrow buttons at the bottom.")]
        public bool ITooExistPurelyToDisplayInfo;
    }
    public class VariousVanitiesConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        [Label("Enable vanity changes?")]
        [Tooltip("Adds vanity item-related changes.")]
        public bool VariousVanitiesEnabled;

        [JsonIgnore]
        public bool _dyedThreads;
        [JsonIgnore]
        public bool _dyes;
        [JsonIgnore]
        public bool _none;

        [DefaultValue(true)]
        [Label("Pre-Boss Familiar set recipes")]
        [Tooltip("Adds recipes for the Familiar vanity set that can be created pre-boss.")]
        public bool PreBossFamiliarSet;

        [DefaultValue(true)]
        [Label("Dryad always sells every Planter Box")]
        [Tooltip("Makes the Dryad always sell every Planter Box (as they are all functionally equivalent).")]
        public bool AlwaysSellPlanterBoxes;

        [Header("Dye Handling In Vanity Recipes")]

        [DefaultValue(true)]
        [Label("Use dyed threads in vanity recipes")]
        [Tooltip("Does not require a world rejoin or mod reload!")]
        public bool DoDyedThreads { get => _dyedThreads; set { if (value) { _dyes = false; _none = false; _dyedThreads = true; } } }

        [DefaultValue(false)]
        [Label("Use dyes in vanity recipes")]
        [Tooltip("Does not require a world rejoin or mod reload!")]
        public bool DoDyes { get => _dyes; set { if (value) { _dyedThreads = false; _none = false; _dyes = true; } } }

        [DefaultValue(false)]
        [Label("Use no color in vanity recipes")]
        [Tooltip("Does not require a world rejoin or mod reload!")]
        public bool DoNone { get => _none; set { if (value) { _dyedThreads = false; _dyes = false; _none = true; } } }

    }
    public class BalancingConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        [Label("Enable balancing changes?")]
        [Tooltip("Adds various balancing changes.")]
        public bool BalancingModuleEnabled;

        [DefaultValue(true)]
        [Label("Molotov Cocktail recipe buff")]
        [Tooltip("Changes the Molotov Cocktail recipe to require 5 Gel instead of 1 Pink Gel.")]
        public bool MolotovRecipeBuff;

        [DefaultValue(true)]
        [Label("Swap Soaring Insignia and Gravity Globe")]
        [Tooltip("In Expert Mode, makes the Moon Lord drop the Soaring Insignia, and the Empress of Light drop the Gravity Globe.")]
        public bool SwapSoaringInsignia;

        [DefaultValue(true)]
        [Label("Magiluminescence recipe nerf")]
        [Tooltip("Changes the Magiluminescence recipe to require 4 Shadow Scales/Tissue Samples.")]
        public bool MagiluminescenceRecipeNerf;

        [DefaultValue(true)]
        [Label("Terraspark Boots recipe nerf")]
        [Tooltip("Changes the Terraspark Boots recipe to require 1 of each Mechanical Boss soul.")]
        public bool TerrasparkBootsRecipeNerf;

        /* You do it, plant
        [DefaultValue(true)]
        [Label("Magiluminescence nerf")]
        [Tooltip("Nerfs the Magiluminescence to a 5% movement speed buff (from 20%).")]
        public bool MagiluminescenceNerf;
        */

        [DefaultValue(true)]
        [Label("Destroyer probe laser glow")]
        [Tooltip("Makes the Pink Lasers shot by Destroyer Probes glow, like all other lasers. This makes them way easier to see at night.")]
        public bool ProbeLaserGlow;
    }

    public class QoLConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [DefaultValue(true)]
        [Label("Enable quality of life changes?")]
        [Tooltip("Adds various quality-of-life changes.")]
        public bool QoLModuleEnabled;

        [DefaultValue(true)]
        [Label("Crate conversion, upgrading and downgrading")]
        [Tooltip("Allows you to convert biome crates to gold crates and back, upgrade crates and downgrade crates.")]
        public bool CrateCrafting;

        [ReloadRequired]
        [DefaultValue(true)]
        [Label("Gem conversion")]
        [Tooltip("Allows you to convert gems to Diamonds and back. Locks sell price of all gems to that of Amethyst. Requires a reload.")]
        public bool GemCrafting;

        [DefaultValue(true)]
        [Label("Chlorophyte Bar recipe buff")]
        [Tooltip("Changes the Chlorophyte Bar recipe to require 4 Chlorophyte Ore, instead of 5. Reduces tedious Chlorophyte grind.")]
        public bool ChlorophyteBarRecipeBuff;

        [DefaultValue(true)]
        [Label("Glowing Mushroom biome enemies drop Mushroom Grass Seeds")]
        [Tooltip("Adds 1 Glowing Mushroom Grass Seeds to the drops of all Glowing Mushroom enemies, at a 10% chance,\nand 2 Glowing Mushroom Grass Seeds at a 100% chance for Truffle Worms.")]
        public bool MushroomEnemiesDropSeeds;

        [DefaultValue(true)]
        [Label("Discount Cookie")]
        [Tooltip("Allows players to craft the Discount Cookie, a consumable item that permanently\ngrants the Discount Card effect (does not stack with Discount Card).")]
        public bool DiscountCookie;

        [DefaultValue(true)]
        [Label("Moon Drop Conversion")]
        [Tooltip("Allows you to convert pet drops from Frost Moon and Pumpkin Moon minibosses to their other drops.")]
        public bool MoonDropConversion;
    }
}
