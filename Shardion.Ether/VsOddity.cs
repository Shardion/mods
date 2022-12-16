using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using VsOddity.Sky;

namespace VsOddity
{
    public class VsOddity : Mod
    {
        public static Mod Instance { get; set; }

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
