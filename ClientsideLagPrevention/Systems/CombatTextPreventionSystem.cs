using System;
using MonoMod.Cil;
using Mono.Cecil.Cil;
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
                IL_CombatText.Update += PreventUpdateText;
                IL_Main.DoDraw += PreventDrawText;
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditUpdateTextFail", e);
            }
        }
        public override void Unload()
        {
            IL_CombatText.Update -= PreventUpdateText;
            IL_Main.DoDraw -= PreventDrawText;
        }

        private static void PreventUpdateText(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel skipRetLabel = c.DefineLabel();
                _ = c.EmitDelegate(ShouldSkipText);
                _ = c.Emit(OpCodes.Brfalse_S, skipRetLabel);
                _ = c.Emit(OpCodes.Ret);
                c.MarkLabel(skipRetLabel);
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditUpdateTextFail", e);
            }
        }

        private static void PreventDrawText(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel skipTextLabel = c.DefineLabel();

                _ = c.GotoNext(i => i.MatchLdsfld<Main>("combatText"), i => i.MatchLdloc(35), i => i.MatchLdelemRef(), i => i.MatchLdfld<CombatText>("active"));
                c.Index -= 3;

                _ = c.EmitDelegate(ShouldSkipText);
                _ = c.Emit(OpCodes.Brtrue_S, skipTextLabel);

                _ = c.GotoNext(i => i.MatchStloc(34), i => i.MatchLdloc(34), i => i.MatchLdcR4(0.0F));
                c.Index--;
                c.MarkLabel(skipTextLabel);
            }
            catch (Exception e)
            {
                CompatibilityWarningSystem.AddCompatibilityWarning("Mods.ClientsideLagPrevention.Common.ILEditDrawTextFail", e);
            }
        }

        private static bool ShouldSkipText()
        {
            return ClientsideLagPrevention.DoIgnoreCombatText == BossConfigurable.Always || (ClientsideLagPrevention.BossAlive && ClientsideLagPrevention.DoIgnoreCombatText == BossConfigurable.IfBossAlive);
        }
    }
}
