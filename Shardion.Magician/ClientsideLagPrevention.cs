using Newtonsoft.Json;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Shardion.Identic;

namespace Shardion.Magician
{
    public enum BossConfigurable
    {
        [Label("$Mods.ClientsideLagPrevention.Config.BossConfigurable.Always")]
        Always,
        [Label("$Mods.ClientsideLagPrevention.Config.BossConfigurable.IfBossAlive")]
        IfBossAlive,
        [Label("$Mods.ClientsideLagPrevention.Config.BossConfigurable.Never")]
        Never,
    }

    public class ClientsideLagPrevention : Mod
    {
        public static bool DoFullbright { get; set; }
        public static bool DoItemCull { get; set; }
        public static BossConfigurable DoItemHide { get; set; }
        public static BossConfigurable DoDustPrevention { get; set; }
        public static BossConfigurable DoCombatTextPrevention { get; set; }
        public static BossConfigurable DoGorePrevention { get; set; }
        public static BossConfigurable DoRainPrevention { get; set; }
        public static bool DoCompatibilityWarnings { get; set; }

        public static bool BossAlive { get; set; }

        public static ClientsideLagPrevention? Instance;

        public override void Load()
        {
            Instance = this;
        }

        public override void Unload()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }

    public class ClientsideLagPreventionConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        [Label("$Mods.ClientsideLagPrevention.Config.FullbrightWhenBossAlive.Label")]
        [Tooltip("$Mods.ClientsideLagPrevention.Config.FullbrightWhenBossAlive.Tooltip")]
        public bool FullbrightWhenBossAlive { get; set; }

        [DefaultValue(true)]
        [Label("$Mods.ClientsideLagPrevention.Config.ItemCulling.Label")]
        [Tooltip("$Mods.ClientsideLagPrevention.Config.ItemCulling.Tooltip")]
        public bool ItemCulling { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [Label("$Mods.ClientsideLagPrevention.Config.HideItems.Label")]
        [Tooltip("$Mods.ClientsideLagPrevention.Config.HideItems.Tooltip")]
        public BossConfigurable HideItems { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [Label("$Mods.ClientsideLagPrevention.Config.DoNotCreateDust.Label")]
        [Tooltip("$Mods.ClientsideLagPrevention.Config.DoNotCreateDust.Tooltip")]
        public BossConfigurable DoNotCreateDust { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [Label("$Mods.ClientsideLagPrevention.Config.DoNotCreateCombatText.Label")]
        [Tooltip("$Mods.ClientsideLagPrevention.Config.DoNotCreateCombatText.Tooltip")]
        public BossConfigurable DoNotCreateCombatText { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [Label("$Mods.ClientsideLagPrevention.Config.DoNotCreateGore.Label")]
        [Tooltip("$Mods.ClientsideLagPrevention.Config.DoNotCreateGore.Tooltip")]
        public BossConfigurable DoNotCreateGore { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [Label("$Mods.ClientsideLagPrevention.Config.DoNotCreateRain.Label")]
        [Tooltip("$Mods.ClientsideLagPrevention.Config.DoNotCreateRain.Tooltip")]
        public BossConfigurable DoNotCreateRain { get; set; }

        [DefaultValue(true)]
        [Label("$Mods.ClientsideLagPrevention.Config.ShowCompatibilityWarnings.Label")]
        [Tooltip("$Mods.ClientsideLagPrevention.Config.ShowCompatibilityWarnings.Tooltip")]
        public bool ShowCompatibilityWarnings { get; set; }

        [Header("$Mods.ClientsideLagPrevention.Config.InfoHeader")]

        [JsonIgnore]
        [Label("$Mods.ClientsideLagPrevention.Config.ViewLicense.Label")]
        [Tooltip("$Mods.ClientsideLagPrevention.Config.ViewLicense.Tooltip")]
        [CustomModConfigItem(typeof(ViewLicenseElement))]
        // Contents are generated from the provided mod's LICENSE file
        public string ViewLicense => "ClientsideLagPrevention";

        [JsonIgnore]
        [Label("$Mods.ClientsideLagPrevention.Config.ViewSource.Label")]
        [Tooltip("$Mods.ClientsideLagPrevention.Config.ViewSource.Tooltip")]
        [CustomModConfigItem(typeof(ViewSourceElement))]
        // Opens the provided URI
        public string ViewSource => "https://github.com/shardion/mods/tree/1.4.4/Shardion.Magician/";

        public override void OnChanged()
        {
            base.OnChanged();
            ClientsideLagPrevention.DoFullbright = FullbrightWhenBossAlive;
            ClientsideLagPrevention.DoItemCull = ItemCulling;
            ClientsideLagPrevention.DoItemHide = HideItems;
            ClientsideLagPrevention.DoDustPrevention = DoNotCreateDust;
            ClientsideLagPrevention.DoCombatTextPrevention = DoNotCreateCombatText;
            ClientsideLagPrevention.DoGorePrevention = DoNotCreateGore;
            ClientsideLagPrevention.DoRainPrevention = DoNotCreateRain;
            ClientsideLagPrevention.DoCompatibilityWarnings = ShowCompatibilityWarnings;
        }
    }

    public class BossCheckerSystem : ModSystem
    {
        int _npcTick;

        public override void PostUpdateNPCs()
        {
            base.PostUpdateNPCs();
            _npcTick++;
            if (_npcTick >= 60) // every second
            {
                ClientsideLagPrevention.BossAlive = false;
                foreach (NPC npc in Main.npc)
                {
                    if (npc.boss && npc.active)
                    {
                        ClientsideLagPrevention.BossAlive = true;
                    }
                }
                _npcTick = 0;
            }
        }
    }
}

// dummy to make tML happy
namespace ClientsideLagPrevention
{
    public class ClientsideLagPrevention
    {
    }
}
