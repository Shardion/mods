using System;
using MonoMod.Cil;
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
                IL_Gore.NewGore_IEntitySource_Vector2_Vector2_int_float += PreventGoreSpawning;
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditNewGoreFail", e);
            }
        }

        private static void PreventGoreSpawning(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel returnMaxGoreLabel = c.DefineLabel();

                _ = c.EmitDelegate(ShouldGoreSpawn);
                _ = c.Emit(Mono.Cecil.Cil.OpCodes.Brfalse_S, returnMaxGoreLabel);

                _ = c.GotoNext(i => i.MatchRet());
                c.Index--;
                c.MarkLabel(returnMaxGoreLabel);
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditNewGoreFail", e);
            }
        }

        private static bool ShouldGoreSpawn()
        {
            if (ClientsideLagPrevention.DoGorePrevention == BossConfigurable.IfBossAlive && ClientsideLagPrevention.BossAlive)
            {
                return false;
            }
            if (ClientsideLagPrevention.DoGorePrevention == BossConfigurable.Always)
            {
                return false;
            }
            return true;
        }
    }
}
