using System;
using Terraria.ModLoader;

namespace Shardion.Flashback.Internal
{
    public abstract class VanityItem : FlashbackItem
    {
        public static string[] FemaleLegTextures { get; set; } = Array.Empty<string>();

        public virtual EquipType ItemEquipType => EquipType.Body;
        public virtual string? FemaleLegTexture => /*UseFemaleLegTexture ? FullNameToTexturePath(GetType().FullName, "_FemaleLegs") :*/ null;
        public virtual bool UseFemaleLegTexture => ItemEquipType == EquipType.Legs;

/*        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            if (!male && FemaleLegTexture != null)
            {
                string[] splitTextureName = FemaleLegTexture.Split("/");
                equipSlot = EquipLoader.GetEquipSlot(Mod, splitTextureName[splitTextureName.GetUpperBound(0)], EquipType.Legs);
            }
        }*/
    }
}