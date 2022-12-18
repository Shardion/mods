// aggressive homing code (mostly) copied from https://github.com/Fargowilta/FargowiltasSouls/blob/d291b31fec237b2c1627bef7aaf2d909b9ec88d9/Projectiles/BossWeapons/DungeonGuardian.cs
// thank you fargo and terry

using System.Linq;
using Microsoft.Xna.Framework;
using Shardion.Zephyros.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Content.VV.Projectiles.Sophisticated
{
    public class RealityRipperProj : ShardProj
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reality Ripper");
        }

        public override void SetDefaults()
        {
            UsePlaceholderSprite = true;
            Projectile.width = 22;
            Projectile.height = 32;
            Projectile.aiStyle = 0;
            AIType = ProjectileID.Bullet;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;
        }

        public override void AI()
        {
            // fargo homing code
            #region fargo home
            Projectile.rotation += 0.2f;

            const int aislotHomingCooldown = 0;
            //int homingDelay = 10;
            int homingDelay = (int)Projectile.ai[1];
            const float desiredFlySpeedInPixelsPerFrame = 60;
            const float amountOfFramesToLerpBy = 20; // minimum of 1, please keep in full numbers even though it's  float!

            Projectile.ai[aislotHomingCooldown]++;
            if (Projectile.ai[aislotHomingCooldown] > homingDelay)
            {
                Projectile.ai[aislotHomingCooldown] = homingDelay; //cap this value 

                NPC n = NPCExists(FindClosestHostileNPC(Projectile.Center, 1000));
                if (n != null)
                {
                    Vector2 desiredVelocity = Projectile.DirectionTo(n.Center) * desiredFlySpeedInPixelsPerFrame;
                    Projectile.velocity = Vector2.Lerp(Projectile.velocity, desiredVelocity, 1f / amountOfFramesToLerpBy);
                }
            }
            #endregion fargo home
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 0;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 50; i++)
            {
                Vector2 pos = new(Projectile.position.X, Projectile.position.Y);
                int dust = Dust.NewDust(pos, Projectile.width, Projectile.height, DustID.Blood, 0, 0, 100, Color.White, 2f);
                Main.dust[dust].noGravity = true;
            }
        }

        // below from https://github.com/Fargowilta/FargowiltasSouls/blob/d291b31fec237b2c1627bef7aaf2d909b9ec88d9/FargoSoulsUtil.cs
        #region fargo util stuff
        public static int FindClosestHostileNPC(Vector2 location, float detectionRange, bool lineCheck = false)
        {
            NPC closestNpc = null;
            foreach (NPC n in Main.npc)
            {
                if (n.CanBeChasedBy() && n.Distance(location) < detectionRange && (!lineCheck || Collision.CanHitLine(location, 0, 0, n.Center, 0, 0)))
                {
                    detectionRange = n.Distance(location);
                    closestNpc = n;
                }
            }
            return closestNpc == null ? -1 : closestNpc.whoAmI;
        }
        public static NPC NPCExists(int whoAmI, params int[] types)
        {
            return whoAmI > -1 && whoAmI < Main.maxNPCs && Main.npc[whoAmI].active && (types.Length == 0 || types.Contains(Main.npc[whoAmI].type)) ? Main.npc[whoAmI] : null;
        }
        #endregion fargo util stuff
    }
}

