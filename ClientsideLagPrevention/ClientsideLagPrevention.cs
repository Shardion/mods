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
        public static BossConfigurable DoSkipBlack { get; set; }
        public static BossConfigurable DoIgnoreDust { get; set; }
        public static BossConfigurable DoIgnoreCombatText { get; set; }
        public static BossConfigurable DoIgnoreGore { get; set; }
        public static BossConfigurable DoIgnoreRain { get; set; }
        public static bool DoCompatibilityWarnings { get; set; }

        public static bool BossAlive { get; set; }

        public static ClientsideLagPrevention? Instance { get; private set; }

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

        [DefaultValue(BossConfigurable.IfBossAlive)]
        public BossConfigurable SkipBlack { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        public BossConfigurable IgnoreDust { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        public BossConfigurable IgnoreCombatText { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        public BossConfigurable IgnoreGore { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        public BossConfigurable IgnoreRain { get; set; }

        [DefaultValue(true)]
        public bool ShowCompatibilityWarnings { get; set; }

        public override void OnChanged()
        {
            base.OnChanged();
            ClientsideLagPrevention.DoSkipBlack = SkipBlack;
            ClientsideLagPrevention.DoIgnoreDust = IgnoreDust;
            ClientsideLagPrevention.DoIgnoreCombatText = IgnoreCombatText;
            ClientsideLagPrevention.DoIgnoreGore = IgnoreGore;
            ClientsideLagPrevention.DoIgnoreRain = IgnoreRain;
            ClientsideLagPrevention.DoCompatibilityWarnings = ShowCompatibilityWarnings;
        }
    }

    public class BossCheckerSystem : ModSystem
    {
        private int _npcTick;

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
