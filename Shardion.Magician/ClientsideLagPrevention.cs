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
        public static BossConfigurable DoDustDeletion { get; set; }
        public static BossConfigurable DoCombatTextDeletion { get; set; }
        public static BossConfigurable DoGoreDeletion { get; set; }
        public static BossConfigurable DoRainDeletion { get; set; }
        public static BossConfigurable DoItemHide { get; set; }
    }

    public class ClientsideLagPreventionConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        [DisplayName("Fullbright if a boss is alive")]
        [Tooltip("Disable the lighting engine when a boss is alive.")]
        public bool FullbrightWhenBossAlive { get; set; }

        [DefaultValue(true)]
        [DisplayName("Cull dropped items")]
        [Tooltip("Only draw dropped items if they are on-screen.")]
        public bool ItemCulling { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [DisplayName("Delete dust")]
        [Tooltip("Delete dust as soon as it spawns.")]
        public BossConfigurable DeleteDust { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [DisplayName("Delete combat text")]
        [Tooltip("Delete combat text as soon as it spawns.")]
        public BossConfigurable DeleteCombatText { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [DisplayName("Delete gore")]
        [Tooltip("Delete gore as soon as it spawns.")]
        public BossConfigurable DeleteGore { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [DisplayName("Delete rain")]
        [Tooltip("Delete rain as soon as it spawns.")]
        public BossConfigurable DeleteRain { get; set; }

        [DefaultValue(BossConfigurable.IfBossAlive)]
        [DisplayName("Hide dropped items")]
        [Tooltip("Disable drawing of dropped items.")]
        public BossConfigurable HideItems { get; set; }

        public override void OnChanged()
        {
            base.OnChanged();
            ClientsideLagPrevention.DoFullbright = FullbrightWhenBossAlive;
            ClientsideLagPrevention.DoItemCull = ItemCulling;
            ClientsideLagPrevention.DoDustDeletion = DeleteDust;
            ClientsideLagPrevention.DoCombatTextDeletion = DeleteCombatText;
            ClientsideLagPrevention.DoGoreDeletion = DeleteGore;
            ClientsideLagPrevention.DoRainDeletion = DeleteRain;
            ClientsideLagPrevention.DoItemHide = HideItems;
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