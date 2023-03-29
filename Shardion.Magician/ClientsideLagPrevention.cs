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
        public static BossConfigurable DoDustDeletion { get; set; }
        public static BossConfigurable DoCombatTextDeletion { get; set; }
        public static BossConfigurable DoGoreDeletion { get; set; }
        public static BossConfigurable DoRainDeletion { get; set; }
    }

    public class ClientsideLagPreventionConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        public bool FullbrightWhenBossAlive { get; set; }
        [DefaultValue(BossConfigurable.IfBossAlive)]
        public BossConfigurable DeleteDust { get; set; }
        [DefaultValue(BossConfigurable.IfBossAlive)]
        public BossConfigurable DeleteCombatText { get; set; }
        [DefaultValue(BossConfigurable.IfBossAlive)]
        public BossConfigurable DeleteGore { get; set; }
        [DefaultValue(BossConfigurable.IfBossAlive)]
        public BossConfigurable DeleteRain { get; set; }

        public override void OnChanged()
        {
            base.OnChanged();
            ClientsideLagPrevention.DoFullbright = FullbrightWhenBossAlive;
            ClientsideLagPrevention.DoDustDeletion = DeleteDust;
            ClientsideLagPrevention.DoCombatTextDeletion = DeleteCombatText;
            ClientsideLagPrevention.DoGoreDeletion = DeleteGore;
            ClientsideLagPrevention.DoRainDeletion = DeleteRain;
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