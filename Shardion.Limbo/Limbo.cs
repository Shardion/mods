using Terraria.ModLoader;

namespace Shardion.Limbo
{
    public class Limbo : Mod
    {
        public static Limbo Instance;

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
