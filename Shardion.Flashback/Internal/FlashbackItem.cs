using Terraria.ModLoader;

namespace Shardion.Flashback.Internal
{
    public abstract class FlashbackItem : ModItem
    {
        public override string Texture => FullNameToTexturePath(GetType().FullName);

        protected string FullNameToTexturePath(string? maybeName)
        {
            return FullNameToTexturePath(maybeName, "");
        }

        protected string FullNameToTexturePath(string? maybeName, string append)
        {
            if (maybeName is string name)
            {
                return name.Replace(".", "/").Replace("Content", "Assets").Replace("Shardion/Flashback", "Shardion.Flashback") + append;
            }
            return base.Texture;
        }
    }
}