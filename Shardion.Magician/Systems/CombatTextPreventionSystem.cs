using System;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class RainPreventionSystem : ModSystem
    {
        public override void Load()
        {
            IL.Terraria.Rain.NewRain += PreventRainSpawning;
        }

        private static void PreventRainSpawning(ILContext il)
        {
            try
            {
                ILCursor c = new ILCursor(il);
                ILLabel returnMaxRainLabel = c.DefineLabel();

                c.EmitDelegate<Func<bool>>(ShouldRainSpawn);
                c.Emit(Mono.Cecil.Cil.OpCodes.Brfalse_S, returnMaxRainLabel);

                c.GotoNext(i => i.MatchRet());
                c.Index--;
                c.MarkLabel(returnMaxRainLabel);
            }
            catch (Exception e)
            {
                Logging.PublicLogger.Error("Clientside Lag Prevention: IL editing MakeRain() failed. Rain cannot be prevented.");
                Logging.PublicLogger.Error(e);
            }
        }

        private static bool ShouldRainSpawn()
        {
            if (ClientsideLagPrevention.DoRainPrevention == BossConfigurable.IfBossAlive && ClientsideLagPrevention.BossAlive)
            {
                return false;
            }
            if (ClientsideLagPrevention.DoRainPrevention == BossConfigurable.Always)
            {
                return false;
            }
            return true;
        }
    }
}