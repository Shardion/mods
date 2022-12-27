using Terraria.ModLoader;

namespace Shardion.Ether.Content.NPCs
{
    public abstract class EtherNPC : ModNPC
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