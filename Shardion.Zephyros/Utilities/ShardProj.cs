using Terraria.ModLoader;

namespace Shardion.Zephyros.Utilities
{
    public abstract class ShardProj : ModProjectile
    {
        public override string Texture => UsePlaceholderSprite ? "ShardionsManyModifications/Assets/ShardPlaceholder" : GetType().ToString().Replace(".", "/").Replace("Content", "Assets");
        public bool UsePlaceholderSprite;
    }
}
