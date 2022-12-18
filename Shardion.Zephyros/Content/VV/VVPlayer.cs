using Shardion.Zephyros.Content.VV.Items.Vanity.Sophisticated;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Shardion.Zephyros.Content.VV
{
    public class VVPlayer : ModPlayer
    {
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            Item[] shardionItems = new Item[] { GetInstance<SophisticatedStockings>().Item, GetInstance<SophisticatedSweater>().Item };
            return Player.name == "shardion" ? shardionItems : Array.Empty<Item>();
        }
    }
}
