using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Shardion.Zephyros.Content.QoL
{
    public class QoLPlayer : ModPlayer
    {
        public bool DiscountCookie;

        public override void SaveData(TagCompound tag)
        {
            List<string> playerData = new();
            if (DiscountCookie)
            {
                playerData.Add("DiscountCookie");
            }
            tag.Add($"{Mod.Name}.{Player.name}.Data", playerData);
        }

        public override void LoadData(TagCompound tag)
        {
            IList<string> playerData = tag.GetList<string>($"{Mod.Name}.{Player.name}.Data");
            DiscountCookie = playerData.Contains("DiscountCookie");
        }

        public override void PostUpdateEquips()
        {
            base.PostUpdateEquips();
            if (DiscountCookie)
            {
                Player.discount = true;
            }
        }
    }
}
