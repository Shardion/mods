using System;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class RainPreventionSystem : ModSystem
    {
        public override void Load()
        {
            // IIRC, this can also throw for different reasons
            try
            {
                IL_Rain.NewRain += PreventRainSpawning;
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditNewRainFail", e);
            }
        }

        private static void PreventRainSpawning(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel returnMaxRainLabel = c.DefineLabel();

                _ = c.EmitDelegate(ShouldRainSpawn);
                _ = c.Emit(Mono.Cecil.Cil.OpCodes.Brfalse_S, returnMaxRainLabel);

                _ = c.GotoNext(i => i.MatchRet());
                c.Index--;
                c.MarkLabel(returnMaxRainLabel);
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditNewRainFail", e);
            }
        }

        private static bool ShouldRainSpawn()
        {
            if (ClientsideLagPrevention.DoRainPrevention == BossConfigurable.IfBossAlive && ClientsideLagPrevention.BossAlive)
            {
                return false;
            }
            if (ClientsideLagPrevention.DoRainPrevention == BossConfigurable.Always)
            {
                return false;
            }
            return true;
        }
    }
}
