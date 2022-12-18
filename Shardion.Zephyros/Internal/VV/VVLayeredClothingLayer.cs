using Shardion.Zephyros.Content.VV.Items.Vanity.LayeredClothing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using static Terraria.DataStructures.PlayerDrawLayers;
using Terraria.ModLoader;

namespace Shardion.Zephyros.Internal.VV
{
    public enum ArmorSlots
    {
        Head,
        Torso,
        Legs
    }

    public enum PlayerLayers
    {
        Head,
        Torso,
        ArmOverItem,
        OffhandAcc,
        BackArms,
        Legs,
        Shoes,
    }

    public abstract class VVLayeredClothingLayer : PlayerDrawLayer
    {
        public virtual ArmorSlots ArmorSlot => ArmorSlots.Head;
        public virtual PlayerLayers PlayerLayer => PlayerLayers.Head;

        public override bool IsHeadLayer => ArmorSlot == ArmorSlots.Head;

        // This looks like ass but OmniSharp says it must be so.
        public override Position GetDefaultPosition()
        {
            return PlayerLayer switch
            {
                PlayerLayers.Head => new Between(Head, FaceAcc),
                PlayerLayers.BackArms => new Between(Skin, Leggings),
                PlayerLayers.ArmOverItem => new Between(ArmOverItem, HandOnAcc),
                PlayerLayers.OffhandAcc => new Between(OffhandAcc, WaistAcc),
                PlayerLayers.Torso => new Between(Torso, OffhandAcc),
                PlayerLayers.Shoes => new Between(Shoes, SkinLongCoat),
                PlayerLayers.Legs => new Between(Leggings, Shoes),
                _ => new Between(Torso, OffhandAcc),
            };
        }

        // P.S.: Dear Jofairden, all I want for the Annual Frost Legion Invasion is `Draw()` on armor.
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            VVDrawModificationPlayer modPlayer = drawInfo.drawPlayer.GetModPlayer<VVDrawModificationPlayer>();
            return ArmorSlot switch
            {
                ArmorSlots.Head => modPlayer.WearingLayeredHead,
                ArmorSlots.Torso => modPlayer.WearingLayeredTorso,
                ArmorSlots.Legs => modPlayer.WearingLayeredLegs,
                _ => false,
            };
        }

        protected sealed override void Draw(ref PlayerDrawSet drawInfo)
        {
            VVDrawModificationPlayer modPlayer = drawInfo.drawPlayer.GetModPlayer<VVDrawModificationPlayer>();
            LayeredClothingItem item;

            switch (ArmorSlot)
            {
                case ArmorSlots.Head:
                    item = modPlayer.LayeredHead;
                    break;
                case ArmorSlots.Torso:
                    item = modPlayer.LayeredTorso;
                    break;
                case ArmorSlots.Legs:
                    item = modPlayer.LayeredLegs;
                    break;
                default:
                    return;
            }

            if (item != null)
            {
                DrawLayeredClothing(ref drawInfo, item);
            }
        }

        protected virtual void DrawLayeredClothing(ref PlayerDrawSet drawInfo, LayeredClothingItem item)
        {
            if (item.BackSlot > 0)
            {
                Item backSlotItem = new(item.BackSlot);
                DrawLayer(ref drawInfo, backSlotItem);
            }
            if (item.MiddleSlot > 0)
            {
                Item middleSlotItem = new(item.MiddleSlot);
                DrawLayer(ref drawInfo, middleSlotItem);
            }
            if (item.FrontSlot > 0)
            {
                Item frontSlotItem = new(item.FrontSlot);
                DrawLayer(ref drawInfo, frontSlotItem);
            }
        }

        protected virtual void DrawLayer(ref PlayerDrawSet drawInfo, Item layerItem)
        {

        }

        protected static Vector2 GetBackArmCompositeOffset(ref PlayerDrawSet drawinfo)
        {
            return new Vector2(6 * ((!drawinfo.playerEffect.HasFlag(SpriteEffects.FlipHorizontally)) ? 1 : (-1)), 2 * ((!drawinfo.playerEffect.HasFlag(SpriteEffects.FlipVertically)) ? 1 : (-1)));
        }

        protected static Vector2 GetFrontArmCompositeOffset(ref PlayerDrawSet drawinfo)
        {
            return new Vector2(-5 * ((!drawinfo.playerEffect.HasFlag(SpriteEffects.FlipHorizontally)) ? 1 : (-1)), 0f);
        }

        protected static bool IsArmorDrawnWhenInvisible(int armorId)
        {
            return false;
        }
    }
}
