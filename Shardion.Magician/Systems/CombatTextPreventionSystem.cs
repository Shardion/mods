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
            IL.Terraria.CombatText.NewText_Rectangle_Color_string_bool_bool += PreventTextSpawning;
        }

        private static void PreventTextSpawning(ILContext il)
        {
            try
            {
                ILCursor c = new ILCursor(il);
                ILLabel returnHundredLabel = c.DefineLabel();

                c.EmitDelegate<Func<bool>>(ShouldTextSpawn);
                c.Emit(Mono.Cecil.Cil.OpCodes.Brfalse_S, returnHundredLabel);

                c.GotoNext(i => i.MatchRet());
                c.Index--;
                c.MarkLabel(returnHundredLabel);
            }
            catch (Exception e)
            {
                Logging.PublicLogger.Error("Clientside Lag Prevention: IL editing NewText() failed. Combat text cannot be prevented.");
                Logging.PublicLogger.Error(e);
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