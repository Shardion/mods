using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria;
using Shardion.Ether.Content.NPCs.Oddity;
using Shardion.Ether.Content.NPCs;

// Based on https://github.com/Fargowilta/FargowiltasSouls/blob/893bf2d6600464a5e768509ad11f250e5bf55ed6/Sky/MutantSky2.cs

namespace Shardion.Ether.Content.Sky
{
    public class OdditySky : CustomSky
    {
        private readonly List<OdditySkyParticle> particles = new();
        private readonly OddityTimer particleTimer = new();
        private readonly Random particleRandom = new();

        private float intensity;
        private const float increment = 0.01f;

        // Minimum for these is always 1.0f
        private static readonly float particleMaxSecondsPerScreen = 2.5f;
        private static readonly float particleMaxScale = 4f;

        private bool isActive;

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 0 && minDepth < 0 && Ether.Instance != null)
            {
                Color odditySkyColor = new Color(0, 0, 0, Convert.ToInt32(intensity * 255));
                spriteBatch.Draw(
                    Ether.Instance.Assets.Request<Texture2D>("Assets/Sky/OdditySky", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value,
                    new Rectangle(0, 0, Main.screenWidth, Main.screenHeight),
                    odditySkyColor
                );
                foreach (OdditySkyParticle particle in particles)
                {
                    // TODO: use the full overload so scale does something
                    spriteBatch.Draw(
                        Ether.Instance.Assets.Request<Texture2D>("Assets/Sky/OdditySkyParticle", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value,
                        particle.Position,
                        Color.White
                    );
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            particleTimer.Ticks++;

            if (EtherGlobalNPC.IsOddityAlive())
            {
                intensity += increment;
                if (intensity > 1f)
                {
                    intensity = 1f;
                }
            }
            else
            {
                intensity -= increment;
                if (intensity < 0f)
                {
                    intensity = 0f;
                    Deactivate();
                }
            }

            for (int index = 0; index < particles.Count; index++)
            {
                // TODO: Ughhhh. Multiple allocations every tick. See if there's a better way.
                OdditySkyParticle updatedParticle = new(
                    particles[index].Position + new Vector2(Main.screenWidth / particles[index].Speed / 60, 0),
                    particles[index].Speed,
                    particles[index].Scale
                );

                particles[index] = updatedParticle;

                if (particles[index].Position.X > Main.screenWidth || particles[index].Position.X < 0)
                {
                    particles.RemoveAt(index);
                }
            }

            if (particleTimer.Ticks % 20 == 0)
            {
                int particleY = particleRandom.Next() % Main.screenHeight;
                float particleSpeed = particleRandom.NextSingle() * particleMaxSecondsPerScreen;
                float particleScale = particleRandom.NextSingle() * particleMaxScale;

                OdditySkyParticle newParticle = new(new Vector2(0, particleY), particleSpeed, particleScale);
                particles.Add(newParticle);
            }
        }

        public override float GetCloudAlpha()
        {
            return 1f - intensity;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            isActive = true;
        }

        public override void Deactivate(params object[] args)
        {
            isActive = false;
        }

        public override void Reset()
        {
            isActive = false;
        }

        public override bool IsActive()
        {
            return isActive;
        }

        public override Color OnTileColor(Color inColor)
        {
            return new Color(Vector4.Lerp(new Vector4(1f, 1f, 0f, 1f), inColor.ToVector4(), 1f - intensity));
        }
    }
}
