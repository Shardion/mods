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

        private static readonly float PARTICLE_MAX_SECONDS_PER_SCREEN = 2.5f;
        private static readonly float PARTICLE_MAX_SCALE = 4f;
        private static readonly float FADE_INTENSITY_STEP = 0.01f;

        private bool _isActive;
        private float _fadeIntensity;

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 0 && minDepth < 0 && Ether.Instance != null)
            {
                Color odditySkyColor = new Color(255, 255, 255, Convert.ToInt32(_fadeIntensity * 255));
                spriteBatch.Draw(
                    Ether.Instance.Assets.Request<Texture2D>("Assets/Sky/OdditySky", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value,
                    new Rectangle(0, 0, Main.screenWidth, Main.screenHeight),
                    odditySkyColor
                );
                foreach (OdditySkyParticle particle in particles)
                {
                    spriteBatch.Draw(
                        Ether.Instance.Assets.Request<Texture2D>("Assets/Sky/OdditySkyParticle", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value,
                        particle.Position,
                        null,
                        Color.White,
                        0f,
                        Vector2.Zero,
                        particle.Scale,
                        SpriteEffects.None,
                        0
                    );
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            particleTimer.Ticks++;

            if (EtherGlobalNPC.IsOddityAlive())
            {
                _fadeIntensity += FADE_INTENSITY_STEP;
                if (_fadeIntensity > 1f)
                {
                    _fadeIntensity = 1f;
                }
            }
            else
            {
                _fadeIntensity -= FADE_INTENSITY_STEP;
                if (_fadeIntensity < 0f)
                {
                    _fadeIntensity = 0f;
                    Deactivate();
                }
            }

            for (int index = 0; index < particles.Count; index++)
            {
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
                float particleSpeed = particleRandom.NextSingle() * PARTICLE_MAX_SECONDS_PER_SCREEN;
                float particleScale = particleRandom.NextSingle() * PARTICLE_MAX_SCALE;

                OdditySkyParticle newParticle = new(new Vector2(0, particleY), particleSpeed, particleScale);
                particles.Add(newParticle);
            }
        }

        public override float GetCloudAlpha()
        {
            return 1f - _fadeIntensity;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            _isActive = true;
        }

        public override void Deactivate(params object[] args)
        {
            _isActive = false;
        }

        public override void Reset()
        {
            _isActive = false;
        }

        public override bool IsActive()
        {
            return _isActive;
        }

        public override Color OnTileColor(Color inColor)
        {
            return new Color(Vector4.Lerp(new Vector4(1f, 1f, 0f, 1f), inColor.ToVector4(), 1f - _fadeIntensity));
        }
    }
}
