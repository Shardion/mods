using System;
using MonoMod.Cil;
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
                IL_Dust.NewDust += PreventDustSpawning;
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditNewDustFail", e);
            }
        }

        private static void PreventDustSpawning(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel returnSixThousandLabel = c.DefineLabel();

                _ = c.EmitDelegate(ShouldDustSpawn);
                _ = c.Emit(Mono.Cecil.Cil.OpCodes.Brfalse_S, returnSixThousandLabel);

                _ = c.GotoNext(i => i.MatchRet());
                c.Index--;
                c.MarkLabel(returnSixThousandLabel);
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditNewDustFail", e);
            }
        }

        private static bool ShouldDustSpawn()
        {
            if (ClientsideLagPrevention.DoDustPrevention == BossConfigurable.IfBossAlive && ClientsideLagPrevention.BossAlive)
            {
                return false;
            }
            if (ClientsideLagPrevention.DoDustPrevention == BossConfigurable.Always)
            {
                return false;
            }
            return true;
        }
    }
}
