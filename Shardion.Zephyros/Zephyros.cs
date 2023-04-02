using Terraria.ModLoader;

namespace Shardion.Zephyros
{
    public class Zephyros : Mod
    {
        // Keeps all user-facing names consistent
        public override string Name => "GameplayRespectingTweaks";
    }
}

// dummy to make tML happy
// for some reason collate stopped generating these
namespace GameplayRespectingTweaks
{
    public class GameplayRespectingTweaks
    {
    }
}