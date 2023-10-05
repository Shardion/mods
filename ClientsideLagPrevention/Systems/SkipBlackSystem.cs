using System;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class SkipBlackSystem : ModSystem
    {
        public override void Load()
        {
            try
            {
                IL_Main.DrawBlack += SkipDrawBlack;
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditDrawBlackFail", e);
            }
        }

        public override void Unload()
        {
            IL_Main.DrawBlack -= SkipDrawBlack;
        }

        private static void SkipDrawBlack(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel skipRetLabel = c.DefineLabel();
                _ = c.EmitDelegate(ShouldSkipBlack);
                _ = c.Emit(OpCodes.Brfalse_S, skipRetLabel);
                _ = c.Emit(OpCodes.Ret);
                c.MarkLabel(skipRetLabel);
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditDrawBlackFail", e);
            }
        }

        private static bool ShouldSkipBlack()
        {
            return ClientsideLagPrevention.DoSkipBlack == BossConfigurable.Always || (ClientsideLagPrevention.BossAlive && ClientsideLagPrevention.DoSkipBlack == BossConfigurable.IfBossAlive);
        }
    }
}
