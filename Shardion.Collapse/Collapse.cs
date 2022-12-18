using Terraria.ModLoader;

namespace Shardion.Collapse
{
    public class Collapse : Mod
    {
        public static Collapse Instance;

        public override void Load()
        {
            Instance = this;
        }

        public override void Unload()
        {
            Instance = null;
        }
    }
}
