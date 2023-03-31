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
            IL.Terraria.Dust.NewDust += PreventDustSpawning;
        }

        private static void PreventDustSpawning(ILContext il)
        {
            try
            {
                ILCursor c = new ILCursor(il);
                ILLabel returnSixThousandLabel = c.DefineLabel();

                c.EmitDelegate<Func<bool>>(ShouldDustSpawn);
                c.Emit(Mono.Cecil.Cil.OpCodes.Brfalse_S, returnSixThousandLabel);

                c.GotoNext(i => i.MatchRet());
                c.Index--;
                c.MarkLabel(returnSixThousandLabel);
            }
            catch (Exception e)
            {
                Logging.PublicLogger.Error("Clientside Lag Prevention: IL editing NewDust() failed. Dust cannot be prevented.");
                Logging.PublicLogger.Error(e);
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