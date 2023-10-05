using System;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class GorePreventionSystem : ModSystem
    {
        public override void Load()
        {
            try
            {
                IL_Gore.Update += PreventGore;
                IL_Main.DrawGore += PreventGore;
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditUpdateGoreFail", e);
            }
        }

        public override void Unload()
        {
            IL_Gore.Update -= PreventGore;
            IL_Main.DrawGore -= PreventGore;
        }

        private static void PreventGore(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel skipRetLabel = c.DefineLabel();
                _ = c.EmitDelegate(ShouldSkipGore);
                _ = c.Emit(OpCodes.Brfalse_S, skipRetLabel);
                _ = c.Emit(OpCodes.Ret);
                c.MarkLabel(skipRetLabel);
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditUpdateGoreFail", e);
            }
        }

        private static bool ShouldSkipGore()
        {
            return ClientsideLagPrevention.DoIgnoreGore == BossConfigurable.Always || (ClientsideLagPrevention.BossAlive && ClientsideLagPrevention.DoIgnoreGore == BossConfigurable.IfBossAlive);
        }
    }
}
