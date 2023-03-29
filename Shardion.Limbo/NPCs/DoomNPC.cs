using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Shardion.Limbo.Doom;

namespace Shardion.Limbo.NPCs
{
    public class DoomNPC : ModNPC
    {
        private static TerrariaDoom doom = new();
        private static int ticTimer = 0;

        public override void SetDefaults()
        {
            NPC.width = 320;
            NPC.height = 200;
            NPC.lifeMax = 100;
            NPC.damage = 100;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            NPC.defense = 100;
            NPC.scale = 1f;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            doom.Draw();
            Texture2D doomTexture = doom.GetDoomTexture();
            Main.EntitySpriteDraw(doomTexture, NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY), null, Color.White, MathHelper.ToRadians(-90f), doomTexture.Size() / 2, 1f, SpriteEffects.FlipHorizontally, 0);
            return false;
        }

        public override void AI()
        {
            // DOOM runs at 20TPS, and Terraria runs at 60.
            ticTimer++;
            if (ticTimer % 3 == 0)
            {
                doom.Update();
            }
        }
    }
}
