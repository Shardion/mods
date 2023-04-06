using System;
using MonoMod.Cil;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class ItemCullingSystem : ModSystem
    {
        public override void Load()
        {
            base.Load();
            IL_Main.DrawItems += HookItemDrawing;
        }

        private static void HookItemDrawing(ILContext il)
        {
            try
            {
                ILCursor c = new(il);
                ILLabel afterDrawLabel = c.DefineLabel();
                ILLabel loopStartLabel = c.DefineLabel();

                _ = c.GotoNext(i => i.MatchLdarg(0));
                c.Index++;
                c.MarkLabel(loopStartLabel);
                _ = c.Emit(Mono.Cecil.Cil.OpCodes.Pop);
                _ = c.Emit(Mono.Cecil.Cil.OpCodes.Ldloc_0);
                _ = c.EmitDelegate(ItemShouldBeDrawn);
                _ = c.Emit(Mono.Cecil.Cil.OpCodes.Brfalse_S, afterDrawLabel);
                _ = c.Emit(Mono.Cecil.Cil.OpCodes.Ldarg_0);

                _ = c.GotoNext(i => i.MatchCall<Main>("DrawItem"));
                c.Index++;
                c.MarkLabel(afterDrawLabel);
            }
            catch (Exception e)
            {
                Logging.PublicLogger.Error("Clientside Lag Prevention: IL editing DrawItems() failed. Items cannot be culled or hidden.");
                Logging.PublicLogger.Error(e);
            }
        }

        private static bool ItemShouldBeDrawn(int index)
        {
            if (ClientsideLagPrevention.DoItemHide == BossConfigurable.Always)
            {
                return false;
            }
            if (ClientsideLagPrevention.DoItemHide == BossConfigurable.IfBossAlive && ClientsideLagPrevention.BossAlive)
            {
                return false;
            }
            if (ClientsideLagPrevention.DoItemCull)
            {
                Rectangle screenRect = new Rectangle((int)Main.screenPosition.X - 800, (int)Main.screenPosition.Y - 800, Main.screenWidth + 1600, Main.screenHeight + 1600);
                return screenRect.Intersects(new Rectangle((int)Main.item[index].position.X, (int)Main.item[index].position.Y, Main.item[index].width, Main.item[index].height));
            }
            return true;
        }

        private static Item ItemFromIndex(int index)
        {
            return Main.item[index];
        }
    }
}
