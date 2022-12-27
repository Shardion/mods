using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.ID;
using Terraria;

namespace Shardion.Ether.Content.Projectiles
{
    public abstract class OddityProjectile : EtherProjectile
    {
        public virtual bool IsStationary => false;

        public sealed override void SetDefaults()
        {
            OdditySetDefaults();
        }

        public sealed override void SetStaticDefaults()
        {
            if (!IsStationary)
            {
                ProjectileID.Sets.TrailingMode[Type] = 2;
                ProjectileID.Sets.TrailCacheLength[Type] = 40;
            }

            OdditySetStaticDefaults();
        }

        public virtual void OdditySetDefaults()
        {

        }

        public virtual void OdditySetStaticDefaults()
        {

        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * Projectile.Opacity;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            if (!IsStationary)
            {
                Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
                Vector2 drawOrigin = new(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
                SpriteEffects spriteEffects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                for (int k = 0; k < Projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                    Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale - (k / 8), spriteEffects, 0f);
                }
            }
            return true;
        }

        /*       public bool DrawFargoTrail(ref Color lightColor)
               {
                   // FIXME: This doesn't work.
                   // The projectile *is* drawn fullbright, but that's all this ends up doing.
                   // No trail is visible.
                   if (!IsStationary)
                   {
                       // Load the Texture2D of the Projectile if it isn't already loaded to reduce bugs.
                       Main.instance.LoadProjectile(Projectile.type);
                       // Get the Texture2D of the Projectile.
                       Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

                       // Get the height of a single frame of the Projectile's Texture2D.
                       int singleFrameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
                       // Get the top of the current frame of the Projectile's Texture2D.
                       // !!! This abuses the fact that Projectile.frame is 0-indexed !!!
                       int singleFrameTop = singleFrameHeight * Projectile.frame;
                       // Make a Rectangle that is the size and position of the current frame in the Projectile's Texture2D.
                       Rectangle projectileSize = new(0, singleFrameTop, projectileTexture.Width, singleFrameHeight);
                       // Make a Vector2 that is at the center of the current frame in the Projectile's Texture2D.
                       // !!! TODO: Not sure how this works !!!
                       Vector2 projectileCenter = projectileSize.Size() / 2f;

                       // Make a copy of the Color that this projectile will be drawn with.
                       Color alphaColor = lightColor;
                       // Remove all color from the Color, leaving only the modified alpha channel.
                       alphaColor = Projectile.GetAlpha(alphaColor);

                       // For every trail segment in the trail cache...
                       for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[Projectile.type]; i++)
                       {
                           // Calculate a Color which is twice as transparent as the parent Projectile.
                           Color halfAlphaColor = alphaColor * 0.5f;
                           // Make the newly-calculated color doubly transparent for every single trail segment after it (achieving a fading effect).
                           //halfAlphaColor *= (ProjectileID.Sets.TrailCacheLength[Projectile.type] - i) / ProjectileID.Sets.TrailCacheLength[Projectile.type];
                           // Get this trail segment's position and rotation.
                           Vector2 trailSegmentPosition = Projectile.oldPos[i];
                           float trailSegmentRotation = Projectile.oldRot[i];
                           // Draw the trail segment.
                           Main.EntitySpriteDraw(projectileTexture, ((trailSegmentPosition + Projectile.Size) / 2f) - Main.screenPosition + new Vector2(0, Projectile.gfxOffY), new Rectangle?(projectileSize), halfAlphaColor, trailSegmentRotation, projectileCenter, Projectile.scale, SpriteEffects.None, 0);
                       }
                   }
                   return true;
               }*/
    }
}
