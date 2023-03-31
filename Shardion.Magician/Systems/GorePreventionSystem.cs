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
            IL.Terraria.Gore.NewGore_IEntitySource_Vector2_Vector2_int_float += PreventGoreSpawning;
        }

        private static void PreventGoreSpawning(ILContext il)
        {
            try
            {
                ILCursor c = new ILCursor(il);
                ILLabel returnMaxGoreLabel = c.DefineLabel();

                c.EmitDelegate<Func<bool>>(ShouldGoreSpawn);
                c.Emit(Mono.Cecil.Cil.OpCodes.Brfalse_S, returnMaxGoreLabel);

                c.GotoNext(i => i.MatchRet());
                c.Index--;
                c.MarkLabel(returnMaxGoreLabel);
            }
            catch (Exception e)
            {
                Logging.PublicLogger.Error("Clientside Lag Prevention: IL editing NewGore() failed. Gores cannot be prevented.");
                Logging.PublicLogger.Error(e);
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