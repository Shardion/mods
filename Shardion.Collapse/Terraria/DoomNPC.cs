using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Shardion.Collapse.Doom;

namespace Shardion.Collapse.Terraria
{
    public class DoomNPC : ModNPC
    {
        private TerrariaDoom doom;

        public DoomNPC()
        {
            doom = new();
        }
    
        public override void SetDefaults()
        {
            NPC.width = 128;
            NPC.height = 128;
            NPC.lifeMax = 100;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (doom.GetDoomTexture() is Texture2D doomTexture)
            {
                spriteBatch.Draw(doomTexture, NPC.position, Color.White);
            }
            return false;
        }

        public override void AI()
        {
            doom.Tick();
        }
    }
}