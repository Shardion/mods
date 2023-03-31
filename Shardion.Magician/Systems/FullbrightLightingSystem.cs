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
            if (ClientsideLagPrevention.DoFullbright && ClientsideLagPrevention.BossAlive && Lighting._activeEngine != _fullbrightEngine)
            {
                _previousLightingEngine = Lighting._activeEngine;
                _previousLightUpdateSetting = Main.LightingEveryFrame;
                Lighting._activeEngine = _fullbrightEngine;
                Main.LightingEveryFrame = false;
            }
            else if (_previousLightingEngine != null && Lighting._activeEngine == _fullbrightEngine)
            {
                Lighting._activeEngine = _previousLightingEngine;
                Main.LightingEveryFrame = _previousLightUpdateSetting;
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