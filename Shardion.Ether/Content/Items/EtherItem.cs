using Terraria.ModLoader;

namespace Shardion.Ether.Content.Items
{
    public abstract class EtherItem : ModItem
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
                return name.Replace(".", "/").Replace("Content", "Assets").Replace("Shardion/Ether", "ShardionsOddEncounter") + append;
            }
            return base.Texture;
        }

    }
}