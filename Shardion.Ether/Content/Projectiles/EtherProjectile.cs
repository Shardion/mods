using Terraria.ModLoader;

namespace Shardion.Ether.Content.Projectiles
{
    public abstract class EtherProjectile : ModProjectile
    {
        public override string Texture => FullNameToTexturePath(GetType().FullName);

        protected string FullNameToTexturePath(string? maybeName)
        {
            return FullNameToTexturePath(maybeName, "");
        }

        protected string FullNameToTexturePath(string? maybeName, string append)
        {
            return (maybeName?.Replace(".", "/").Replace("Content", "Assets").Replace("Shardion/Ether", "ShardionsOddEncounter") + append) ?? base.Texture;
        }
    }
}
