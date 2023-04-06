using System;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class CombatTextPreventionSystem : ModSystem
    {
        public override void Load()
        {
            try
            {
                IL_CombatText.NewText_Rectangle_Color_string_bool_bool += PreventTextSpawning;
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditNewTextFail", e);
            }
        }

        private static void PreventTextSpawning(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel returnHundredLabel = c.DefineLabel();

                _ = c.EmitDelegate(ShouldTextSpawn);
                _ = c.Emit(Mono.Cecil.Cil.OpCodes.Brfalse_S, returnHundredLabel);

                _ = c.GotoNext(i => i.MatchRet());
                c.Index--;
                c.MarkLabel(returnHundredLabel);
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditNewTextFail", e);
            }
        }

        private static bool ShouldTextSpawn()
        {
            if (ClientsideLagPrevention.DoCombatTextPrevention == BossConfigurable.IfBossAlive && ClientsideLagPrevention.BossAlive)
            {
                return false;
            }
            if (ClientsideLagPrevention.DoCombatTextPrevention == BossConfigurable.Always)
            {
                return false;
            }
            return true;
        }
    }
}
