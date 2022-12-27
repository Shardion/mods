using Terraria;

namespace Shardion.Ether.Content.Projectiles.Visual
{
    public class UltimateTruth : OddityProjectile
    {
        public override void OdditySetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.damage = 0;
            Projectile.tileCollide = false;
        }

        public override bool CanHitPlayer(Player target)
        {
            return false;
        }
    }
}
