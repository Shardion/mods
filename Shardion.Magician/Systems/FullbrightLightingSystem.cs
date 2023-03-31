using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Light;
using Terraria.ModLoader;

namespace Shardion.Magician.Systems
{
    public class FullbrightSystem : ModSystem
    {
        private static readonly Type _lightingManagerType = typeof(Lighting);
        private static readonly FullbrightLightingEngine _fullbrightEngine = new FullbrightLightingEngine();

        private static ILightingEngine? _previousLightingEngine;
        private static bool _previousLightUpdateSetting;
        public override void PostDrawTiles() // No appropriate "pre" method
        {
            base.PostDrawTiles();

            // TODO: Reflection to access a field, can be replaced with compiler trickery to do it natively for free FPS(?)
            // This is still faster than vanilla though
            FieldInfo? currentLightingEngine = _lightingManagerType.GetField("_activeEngine", BindingFlags.NonPublic | BindingFlags.Static);
            if (currentLightingEngine != null)
            {
                if (ClientsideLagPrevention.DoFullbright && ClientsideLagPrevention.BossAlive)
                {
                    if (currentLightingEngine.GetValue(null) is ILightingEngine _lightingEngine && _lightingEngine != _fullbrightEngine)
                    {
                        _previousLightingEngine = _lightingEngine;
                        currentLightingEngine.SetValue(null, _fullbrightEngine);
                        _previousLightUpdateSetting = Main.LightingEveryFrame;
                        Main.LightingEveryFrame = false;
                    }
                }
                else
                {
                    if (currentLightingEngine.GetValue(null) == _fullbrightEngine)
                    {
                        currentLightingEngine.SetValue(null, _previousLightingEngine);
                        Main.LightingEveryFrame = _previousLightUpdateSetting;
                    }
                }
            }
        }
    }

    public class FullbrightLightingEngine : ILightingEngine
    {
        public Vector3 GetColor(int x, int y)
        {
            return Vector3.One;
        }

        public void Rebuild() { } // No-op
        public void Clear() { } // No-op
        public void AddLight(int x, int y, Vector3 color) { } // No-op
        public void ProcessArea(Rectangle area) { } // No-op
    }
}