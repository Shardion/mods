using Terraria.ModLoader;
using Shardion.Flashback.Internal;

namespace Shardion.Flashback.Content.Vanity.Dev
{
/*    [AutoloadEquip(EquipType.Head)]
    public abstract class ShardionsHat : VanityItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
        }
    }*/

    [AutoloadEquip(EquipType.Body)]
    public class ShardionsBody : VanityItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
        }
    }

    [AutoloadEquip(EquipType.Legs)]
    public class ShardionsLegs : VanityItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
        }
    }
}