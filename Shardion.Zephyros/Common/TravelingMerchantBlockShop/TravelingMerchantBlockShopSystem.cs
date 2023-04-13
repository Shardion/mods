using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Common.TravelingMerchantBlockShop
{
    public class TravelingMerchantBlockShopSystem : ModSystem
    {
        private static readonly int MAX_BASIC_BLOCKS = 2;
        private static readonly int MAX_STRUCTURAL_BLOCKS = 4;
        private static readonly int MAX_DECORATIVE_BLOCKS = 3;
        private static readonly int MAX_EXOTIC_BLOCKS = 1;
        private static readonly float EXOTIC_CHANCE = 0.50f;

        public static ICollection<Item> BlockShopContents = new List<Item>();

        private bool _wasDay;

        public override void PostUpdateTime()
        {
            base.PostUpdateTime();
            if (Main.dayTime && !_wasDay)
            {
                BlockShopContents = RollBlockShop();
            }
            if (Main.time % 60 == 0)
            {
                BlockShopContents = RollBlockShop();
            }
            _wasDay = Main.dayTime;
        }

        private List<Item> RollBlockShop()
        {
            List<Item> rolledBlocks = new();

            List<Item> basicBlocks = new();
            List<Item> structuralBlocks = new();
            List<Item> decorativeBlocks = new();
            List<Item> exoticBlocks = new();

            foreach (IBlockGroup group in GetAllGroups())
            {
                group.LoadItems(Mod);
                switch (group.Pool)
                {
                    case BlockGroupPool.Basic:
                        basicBlocks.Add(group.GetRandomItem());
                        break;
                    case BlockGroupPool.Structural:
                        structuralBlocks.Add(group.GetRandomItem());
                        break;
                    case BlockGroupPool.Decorative:
                        decorativeBlocks.Add(group.GetRandomItem());
                        break;
                    case BlockGroupPool.Exotic:
                        exoticBlocks.Add(group.GetRandomItem());
                        break;
                }
            }
            MoveRandomEntries(MAX_BASIC_BLOCKS, basicBlocks, rolledBlocks);
            MoveRandomEntries(MAX_STRUCTURAL_BLOCKS, structuralBlocks, rolledBlocks);
            MoveRandomEntries(MAX_DECORATIVE_BLOCKS, decorativeBlocks, rolledBlocks);
            if (Main.rand.NextFloat() >= EXOTIC_CHANCE)
            {
                MoveRandomEntries(MAX_EXOTIC_BLOCKS, exoticBlocks, rolledBlocks);
            }

            return rolledBlocks;
        }

        private static void MoveRandomEntries(int count, List<Item> from, List<Item> to)
        {
            Item rolledEntry;
            int maxMovable = Math.Min(count, from.Count);
            for (int moveCap = 0; moveCap < maxMovable; moveCap++)
            {
                rolledEntry = Main.rand.NextFromCollection<Item>(from);
                to.Add(rolledEntry);
                from.Remove(rolledEntry);
            }
        }

        private List<IBlockGroup> GetAllGroups()
        {
            List<IBlockGroup> groups = new();
            foreach (Type type in GetType().Assembly.GetExportedTypes())
            {
                if (type.IsAssignableTo(typeof(IBlockGroup)) && !type.IsAbstract)
                {
                    if (type.GetConstructor(Array.Empty<Type>())?.Invoke(Array.Empty<Type>()) is IBlockGroup group)
                    {
                        groups.Add(group);
                    }
                }
            }
            return groups;
        }
    }
}