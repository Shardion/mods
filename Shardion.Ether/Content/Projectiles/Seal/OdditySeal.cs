using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Ether.Content.Projectiles.Seal
{
    public class OdditySeal : OddityProjectile
    {
        //private List<Projectile> _sealSegments;
        private Vector2 _centerPos;
        private bool _firstRun;

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

        public override void AI()
        {
            _centerPos = new Vector2(Projectile.ai[0], Projectile.ai[1]);
            if (!_firstRun)
            {
                CreateSealProjectiles();
                _firstRun = true;
            }
        }

        private void CreateSealProjectiles()
        {
            int segmentId = ModContent.GetInstance<OdditySealSegment>().Type;
            float segmentDistanceFromCenter = 500f;
            Vector2 segmentPositionBase = new(_centerPos.X + segmentDistanceFromCenter, _centerPos.Y);
            for (int angle = 0; angle <= 180; angle += 10)
            {
                Vector2 segmentPosition = segmentPositionBase.RotatedBy(angle, _centerPos);
                _ = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), segmentPosition, Vector2.Zero, segmentId, 1000, 0);
            }
        }
    }
}
