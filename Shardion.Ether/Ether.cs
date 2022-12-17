using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Shardion.Ether.Sky;

namespace Shardion.Ether
{
    public class Ether : Mod
    {
        public static Mod? Instance { get; set; }

        public override void Load()
        {
            Instance = this;
            SkyManager.Instance["VsOddity:Oddity"] = new OdditySky();
        }

        public override void Unload()
        {
            Instance = null;
        }
    }
}
