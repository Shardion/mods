using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content.Balancing.Projectiles
{
    public class BalancingGlobalProjectile : GlobalProjectile
    {

        public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
            return projectile.type == ProjectileID.PinkLaser && ModContent.GetInstance<Utilities.BalancingConfig>().ProbeLaserGlow ?
                Color.White * projectile.Opacity : base.GetAlpha(projectile, lightColor);
        }
    }
}
