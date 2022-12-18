using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Shardion.Zephyros.Utilities;
using Shardion.Zephyros.Internal.VV;
namespace Shardion.Zephyros.Content.VV.Items.Vanity.LayeredClothing
{
    public abstract class LayeredClothingItem : ShardItem
    {
        public virtual ArmorSlots ArmorSlot => ArmorSlots.Torso;

        public int FrontSlot { get; set; }
        public int MiddleSlot { get; set; }
        public int BackSlot { get; set; }

        public sealed override void SetDefaults()
        {
            Item.vanity = true;
            Item.rare = ItemRarityID.Blue; // Vanity items aren't that rare
            SetLayeredClothingDefaults();
        }

        public virtual void SetLayeredClothingDefaults()
        {
            BackSlot = ItemID.SpiderBreastplate;
            MiddleSlot = 0;
            FrontSlot = ItemID.NecroBreastplate;
        }

        public override void EquipFrameEffects(Player player, EquipType type)
        {
            switch (ArmorSlot)
            {
                case ArmorSlots.Head:
                    player.GetModPlayer<VVDrawModificationPlayer>().WearingLayeredHead = true;
                    player.GetModPlayer<VVDrawModificationPlayer>().LayeredHead = this;
                    break;
                case ArmorSlots.Torso:
                    player.GetModPlayer<VVDrawModificationPlayer>().WearingLayeredTorso = true;
                    player.GetModPlayer<VVDrawModificationPlayer>().LayeredTorso = this;
                    break;
                case ArmorSlots.Legs:
                    player.GetModPlayer<VVDrawModificationPlayer>().WearingLayeredLegs = true;
                    player.GetModPlayer<VVDrawModificationPlayer>().LayeredLegs = this;
                    break;
                default:
                    break;
            };
        }

        public override void SaveData(TagCompound tag)
        {
            SaveItemData(tag, "Front", FrontSlot);
            SaveItemData(tag, "Middle", MiddleSlot);
            SaveItemData(tag, "Back", BackSlot);
        }

        public override void LoadData(TagCompound tag)
        {
            FrontSlot = LoadItemData(tag, "Front");
            MiddleSlot = LoadItemData(tag, "Middle");
            BackSlot = LoadItemData(tag, "Back");
        }

        private static void SaveItemData(TagCompound tag, string name, int id)
        {
            ModItem moddedItem = ModContent.GetModItem(id);
            if (moddedItem != null)
            {
                tag.Add("modded" + name, moddedItem.Name);
                tag.Add("vanilla" + name, 0);
            }
            else
            {
                tag.Add("modded" + name, null);
                tag.Add("vanilla" + name, id);
            }
        }

        private static int LoadItemData(TagCompound tag, string name)
        {
            if (tag.TryGet("vanilla" + name, out int vanillaId))
            {
                if (vanillaId != 0)
                {
                    return vanillaId;
                }
            }
            if (tag.TryGet("modded" + name, out string moddedId))
            {
                if (ModContent.TryFind(moddedId, out ModItem moddedItem))
                {
                    return moddedItem.Type;
                }
            }
            return 0;
        }
    }

    [AutoloadEquip(EquipType.Body)]
    public class ExampleLayeredClothing : LayeredClothingItem
    {
        public override ArmorSlots ArmorSlot => ArmorSlots.Torso;
    }

    [AutoloadEquip(EquipType.Legs)]
    public class BlackThighHighSocks : LayeredClothingItem
    {
        public override ArmorSlots ArmorSlot => ArmorSlots.Legs;

        public override void SetLayeredClothingDefaults()
        {
            Item.width = 28;
            Item.height = 30;
        }
    }
}
