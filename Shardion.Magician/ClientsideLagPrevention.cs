using System.ComponentModel;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace Shardion.Magician
{
    public enum BossConfigurable
    {
        Always,
        IfBossAlive,
        Never,
    }

    public class ClientsideLagPrevention : Mod
    {
        public static bool BossAlive { get; set; }
        public static bool DoFullbright { get; set; }
        public static bool DoItemCull { get; set; }
        public static BossConfigurable DoItemHide { get; set; }
        public static BossConfigurable DoDustPrevention { get; set; }
        public static BossConfigurable DoCombatTextPrevention { get; set; }
        public static BossConfigurable DoGorePrevention { get; set; }
        public static BossConfigurable DoRainPrevention { get; set; }
    }

    public class ClientsideLagPreventionConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        [DisplayName("Fullbright if a boss is alive")]
        [Tooltip("Disable the lighting engine when a boss is alive.")]
        public bool FullbrightWhenBossAlive { get; set; }

        [DefaultValue(true)]
        [DisplayName("Do not draw offscreen dropped items")]
        [Tooltip("Only draw dropped items if they are on-screen.")]
        public bool ItemCulling { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [DisplayName("Hide dropped items")]
        [Tooltip("Disable drawing of dropped items.")]
        public BossConfigurable HideItems { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [DisplayName("Disable dust")]
        [Tooltip("Disables creation of dust.")]
        public BossConfigurable DoNotCreateDust { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [DisplayName("Disable combat text")]
        [Tooltip("Disables creation of combat text.")]
        public BossConfigurable DoNotCreateCombatText { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [DisplayName("Disable gore")]
        [Tooltip("Disables creation of gore.")]
        public BossConfigurable DoNotCreateGore { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [DisplayName("Disable rain")]
        [Tooltip("Disables creation of rain.")]
        public BossConfigurable DoNotCreateRain { get; set; }

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