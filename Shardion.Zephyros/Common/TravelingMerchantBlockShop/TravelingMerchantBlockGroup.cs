using System;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Common.TravelingMerchantBlockShop
{
    public enum BlockGroupPool
    {
        Basic,
        Structural,
        Decorative,
        Exotic,
    }

    public interface IBlockGroup
    {
        /// <summary>
        /// Which pool this <c>IBlockGroup</c> exists in.
        /// </summary>
        public BlockGroupPool Pool { get; }

        /// <summary>
        /// Called immediately before use of the <c>IBlockGroup</c> (i.e. when opening the Traveling Merchant's block shop).
        /// Allows implementors to load any item lists they may have.
        /// </summary>
        public void LoadItems(Mod mod);

        /// <summary>
        /// Gets a random item from this <c>IBlockGroup</c>.
        /// </summary>
        public Item GetRandomItem();
    }

    public abstract class EvenSpreadBlockGroup : IBlockGroup
    {
        public virtual BlockGroupPool Pool => BlockGroupPool.Decorative;
        protected Item[] Items { get; set; } = Array.Empty<Item>();
        public int DefaultValue => 200;

        public void LoadItems(Mod mod)
        {
            Items = OnLoadItems(mod);
        }

        public virtual Item[] OnLoadItems(Mod mod)
        {
            return Array.Empty<Item>();
        }

        public Item GetRandomItem()
        {
            return Main.rand.NextFromList<Item>(Items);
        }

        public Item DefaultItem(int id)
        {
            Item item = new Item();
            item.SetDefaults(id);
            if (item.value == 0)
            {
                item.value = DefaultValue;
            }
            return item;
        }
    }
}