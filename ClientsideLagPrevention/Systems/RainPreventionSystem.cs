using System;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class RainPreventionSystem : ModSystem
    {
        public override void Load()
        {
            try
            {
                IL_Rain.Update += PreventRain;
                IL_Main.DrawRain += PreventRain;
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditUpdateRainFail", e);
            }
        }

        public override void Unload()
        {
            IL_Rain.Update -= PreventRain;
            IL_Main.DrawRain -= PreventRain;
        }

        private static void PreventRain(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel skipRetLabel = c.DefineLabel();
                _ = c.EmitDelegate(ShouldSkipRain);
                _ = c.Emit(OpCodes.Brfalse_S, skipRetLabel);
                _ = c.Emit(OpCodes.Ret);
                c.MarkLabel(skipRetLabel);
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditUpdateRainFail", e);
            }
        }

        private static bool ShouldSkipRain()
        {
            return ClientsideLagPrevention.DoIgnoreRain == BossConfigurable.Always || (ClientsideLagPrevention.BossAlive && ClientsideLagPrevention.DoIgnoreRain == BossConfigurable.IfBossAlive);
        }
    }
}
