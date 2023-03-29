using Terraria;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class DustKillerSystem : ModSystem
    {
        public override void PostUpdateDusts()
        {
            if ((ClientsideLagPrevention.DoDustDeletion == BossConfigurable.IfBossAlive && ClientsideLagPrevention.BossAlive) || ClientsideLagPrevention.DoDustDeletion == BossConfigurable.Always)
            {
                foreach (Dust dust in Main.dust)
                {
                    dust.active = false;
                }
            }
        }
    }

    public class CombatTextKillerSystem : ModSystem
    {
        public override void PostUpdateDusts() // No appropriate method for combat texts
        {
            if ((ClientsideLagPrevention.DoCombatTextDeletion == BossConfigurable.IfBossAlive && ClientsideLagPrevention.BossAlive) || ClientsideLagPrevention.DoCombatTextDeletion == BossConfigurable.Always)
            {
                foreach (CombatText combatText in Main.combatText)
                {
                    combatText.active = false;
                }
            }
        }
    }

    public class GoreKillerSystem : ModSystem
    {
        public override void PostUpdateGores()
        {
            if ((ClientsideLagPrevention.DoGoreDeletion == BossConfigurable.IfBossAlive && ClientsideLagPrevention.BossAlive) || ClientsideLagPrevention.DoGoreDeletion == BossConfigurable.Always)
            {
                foreach (Gore gore in Main.gore)
                {
                    gore.active = false;
                }
            }
        }
    }

    public class RainKillerSystem : ModSystem
    {
        public override void PostUpdateWorld() // No appropriate method for rain
        {
            if ((ClientsideLagPrevention.DoRainDeletion == BossConfigurable.IfBossAlive && ClientsideLagPrevention.BossAlive) || ClientsideLagPrevention.DoRainDeletion == BossConfigurable.Always)
            {
                foreach (Rain rain in Main.rain)
                {
                    rain.active = false;
                }
            }
        }
    }
}