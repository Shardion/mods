using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Utilities
{
    public abstract class ShardItem : ModItem
    {
        public enum DevIndex
        {
            Shardion
        }

        // We have a separate assets folder to keep the code clean and separated from the assets
        // As a side effect, this also enforces that items are always content
        // Additionally this allows us to automatically add placeholder sprites and tooltips
        public override string Texture => UsePlaceholderSprite ? "ShardionsManyModifications/Assets/ShardPlaceholder" : GetType().ToString().Replace(".", "/").Replace("Content", "Assets");

        public virtual bool UsePlaceholderSprite => false;

        public static readonly string[,] Developers = new string[,] { { "shardion", "00FFEE" } };

        public string FemaleLegsTexture;

        public int Developer = -1;

        public string Variant;

        public virtual void VVModifyTooltips(List<TooltipLine> tooltips) { }

        public sealed override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            VVModifyTooltips(tooltips);
            if (Developer != -1)
            {
                tooltips.Add(new TooltipLine(Mod, "Developer Item Of", "[c/" + Developers[Developer, 1] + ":Developer item: " + Developers[Developer, 0] + "]"));
            }
            if (Variant != null)
            {
                tooltips.Add(new TooltipLine(Mod, "Item Variant", "Variant: " + Variant));
            }
            if (UsePlaceholderSprite)
            {
                tooltips.Add(new TooltipLine(Mod, "Sprite Request", "This item is currently using a placeholder sprite. If you want to contribute a sprite for it, join our Discord!"));
            }
        }

        public virtual void VVSetMatch(bool male, ref int equipSlot, ref bool robes) { }
        public sealed override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            VVSetMatch(male, ref equipSlot, ref robes);
            if (!male && FemaleLegsTexture != null)
            {
                equipSlot = EquipLoader.GetEquipSlot(Mod, FemaleLegsTexture, EquipType.Legs);
            }
        }

        public void AddVariantRecipe(ModItem from, ModItem variant)
        {
            _ = variant.CreateRecipe()
                .AddIngredient(from)
                .AddTile(TileID.Loom)
                .Register();
            _ = from.CreateRecipe()
                .AddIngredient(variant)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
