using System;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class DustPreventionSystem : ModSystem
    {
        public override void Load()
        {
            try
            {
                IL_Dust.UpdateDust += PreventDust;
                IL_Main.DrawDust += PreventDust;
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditUpdateDustFail", e);
            }
        }

        public override void Unload()
        {
            IL_Dust.UpdateDust -= PreventDust;
            IL_Main.DrawDust -= PreventDust;
        }

        private static void PreventDust(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel skipRetLabel = c.DefineLabel();
                _ = c.EmitDelegate(ShouldSkipDust);
                _ = c.Emit(OpCodes.Brfalse_S, skipRetLabel);
                _ = c.Emit(OpCodes.Ret);
                c.MarkLabel(skipRetLabel);
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditUpdateDustFail", e);
            }
        }

        private static bool ShouldSkipDust()
        {
            return ClientsideLagPrevention.DoIgnoreDust == BossConfigurable.Always || (ClientsideLagPrevention.BossAlive && ClientsideLagPrevention.DoIgnoreDust == BossConfigurable.IfBossAlive);
        }
    }
}
