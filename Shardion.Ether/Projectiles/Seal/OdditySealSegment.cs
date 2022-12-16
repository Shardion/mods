using Terraria;

namespace VsOddity.Projectiles.Seal
{
    public class OdditySealSegment : OddityProjectile
    {
        public override void OdditySetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.damage = 0;
            Projectile.tileCollide = false;
            Projectile.scale = 4f;
        }

        public override bool CanHitPlayer(Player target)
        {
            return false;
        }
    }
}