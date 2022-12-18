using Terraria.DataStructures;
using Terraria.ModLoader;
using Shardion.Zephyros.Content.VV.Items.Vanity.LayeredClothing;

namespace Shardion.Zephyros.Internal.VV
{
    public class VVDrawModificationPlayer : ModPlayer
    {
        public bool WearingLayeredHead { get; set; }
        public bool WearingLayeredTorso { get; set; }
        public bool WearingLayeredLegs { get; set; }

        public LayeredClothingItem LayeredHead { get; set; }
        public LayeredClothingItem LayeredTorso { get; set; }
        public LayeredClothingItem LayeredLegs { get; set; }

        public override void HideDrawLayers(PlayerDrawSet drawInfo)
        {
            if (WearingLayeredHead)
            {
                PlayerDrawLayers.Head.Hide();
            }

            if (WearingLayeredTorso)
            {
                PlayerDrawLayers.Torso.Hide();
                PlayerDrawLayers.ArmOverItem.Hide();
            }

            if (WearingLayeredLegs)
            {
                PlayerDrawLayers.Leggings.Hide();
                PlayerDrawLayers.Shoes.Hide();
            }
        }

        public override void ResetEffects()
        {
            WearingLayeredHead = false;
            WearingLayeredTorso = false;
            WearingLayeredLegs = false;
            LayeredHead = null;
            LayeredTorso = null;
            LayeredLegs = null;
        }
    }
}
