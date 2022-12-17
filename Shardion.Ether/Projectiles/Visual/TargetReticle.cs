using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace Shardion.Ether.Projectiles.Visual
{
    public class TargetReticle : OddityProjectile
    {
        public override void OdditySetDefaults()
        {
            Projectile.width = 110;
            Projectile.height = 110;
            Projectile.timeLeft = 150;
            Projectile.damage = 10;
            Projectile.hostile = true;
        }

        public override bool CanHitPlayer(Player target)
        {
            return false;
        }

        // `AI()`, `GetAlpha()` and `PreDraw()` SHAMELESSLY stolen from fargo's soul mod (`MutantReticle.cs`) and modified
        public override void AI()
        {
            if (Projectile.localAI[0] == 0)
            {
                Projectile.localAI[0] = Main.rand.NextBool() ? -1 : 1;
                Projectile.rotation = Main.rand.NextFloat((float)(Math.PI * 2));
            }

            int modifier = Math.Min(60, 90 - Projectile.timeLeft);

            Projectile.scale = 0.5f + (0.5f / (60f * modifier)); // start small, scale up

            Projectile.velocity = Vector2.Zero;
            Projectile.rotation += MathHelper.ToRadians(6) * Projectile.localAI[0];

            if (Projectile.timeLeft < 15)
            {
                Projectile.alpha += 17;
            }
            else
            {
                Projectile.alpha -= 4;
                if (Projectile.alpha < 0) //fade in
                {
                    Projectile.alpha = 0;
                }
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 128) * ((1f - Projectile.alpha) / 255f);
        }
    }
}
