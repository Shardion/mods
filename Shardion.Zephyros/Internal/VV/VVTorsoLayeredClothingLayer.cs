using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using static Terraria.DataStructures.PlayerDrawLayers;
using Terraria.GameContent;
using System.Collections.Generic;

namespace Shardion.Zephyros.Internal.VV
{
    public class VVTorsoLayeredClothingLayer : VVLayeredClothingLayer
    {
        public override ArmorSlots ArmorSlot => ArmorSlots.Torso;
        public override PlayerLayers PlayerLayer => PlayerLayers.Torso;

        // 1.3 torso drawing function
        protected override void DrawLayer(ref PlayerDrawSet drawInfo, Item layerItem)
        {
            int layerId = layerItem.bodySlot;
            if (drawInfo.usesCompositeTorso)
            {
                DrawTorsoLayerComposite(ref drawInfo, layerId);
            }
            else if (layerId > 0)
            {
                Rectangle bodyFrame = drawInfo.drawPlayer.bodyFrame;
                int num = drawInfo.armorAdjust;
                bodyFrame.X += num;
                bodyFrame.Width -= num;
                if (drawInfo.drawPlayer.direction == -1)
                {
                    num = 0;
                }
                if (!drawInfo.drawPlayer.invis || (layerId != 21 && layerId != 22))
                {
                    Texture2D texture = drawInfo.drawPlayer.Male ? TextureAssets.ArmorBody[layerId].Value : TextureAssets.FemaleBody[layerId].Value;
                    DrawData item = new(texture, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)) + num, (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), bodyFrame, drawInfo.colorArmorBody, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                    {
                        shader = drawInfo.cBody
                    };
                    drawInfo.DrawDataCache.Add(item);
                    if (drawInfo.bodyGlowMask != -1)
                    {
                        item = new(TextureAssets.GlowMask[drawInfo.bodyGlowMask].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)) + num, (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), bodyFrame, drawInfo.bodyGlowColor, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                        {
                            shader = drawInfo.cBody
                        };
                        drawInfo.DrawDataCache.Add(item);
                    }
                }
                if (!drawInfo.armorHidesHands && !drawInfo.drawPlayer.invis)
                {
                    DrawHands(ref drawInfo);
                }
            }
            else if (!drawInfo.drawPlayer.invis)
            {
                DrawData item;
                if (!drawInfo.drawPlayer.Male)
                {
                    item = new DrawData(TextureAssets.Players[drawInfo.skinVar, 4].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorUnderShirt, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0);
                    drawInfo.DrawDataCache.Add(item);
                    item = new DrawData(TextureAssets.Players[drawInfo.skinVar, 6].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorShirt, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0);
                    drawInfo.DrawDataCache.Add(item);
                }
                else
                {
                    item = new DrawData(TextureAssets.Players[drawInfo.skinVar, 4].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorUnderShirt, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0);
                    drawInfo.DrawDataCache.Add(item);
                    item = new DrawData(TextureAssets.Players[drawInfo.skinVar, 6].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorShirt, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0);
                    drawInfo.DrawDataCache.Add(item);
                }
                // something to do with hands?
                // mess with this later
                DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 5].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorBodySkin, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                {
                    shader = drawInfo.skinDyePacked
                };
                item = drawData;
                drawInfo.DrawDataCache.Add(item);
            }
        }

        // 1.4 torso drawing function
        protected void DrawTorsoLayerComposite(ref PlayerDrawSet drawInfo, int layerItemId)
        {
            Vector2 vector = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2);
            Vector2 value = Main.OffsetsPlayerHeadgear[drawInfo.drawPlayer.bodyFrame.Y / drawInfo.drawPlayer.bodyFrame.Height];
            value.Y -= 2f;
            vector += value * -drawInfo.playerEffect.HasFlag(SpriteEffects.FlipVertically).ToDirectionInt();
            float bodyRotation = drawInfo.drawPlayer.bodyRotation;
            Vector2 vector2 = vector;
            Vector2 bodyVect = drawInfo.bodyVect;
            Vector2 compositeOffset_BackArm = GetBackArmCompositeOffset(ref drawInfo);
            _ = vector2 + compositeOffset_BackArm;
            bodyVect += compositeOffset_BackArm;
            if (layerItemId > 0)
            {
                if (!drawInfo.drawPlayer.invis)
                {
                    Main.instance.LoadArmorBody(layerItemId);
                    Texture2D value2 = TextureAssets.ArmorBodyComposite[layerItemId].Value;
                    DrawData drawData2 = new(value2, vector, drawInfo.compTorsoFrame, drawInfo.colorArmorBody, bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                    {
                        shader = drawInfo.cBody
                    };
                    DrawCompositeArmorPiece(ref drawInfo, CompositePlayerDrawContext.Torso, drawData2);
                }
            }
            else if (!drawInfo.drawPlayer.invis)
            {
                drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 4].Value, vector, drawInfo.compBackShoulderFrame, drawInfo.colorUnderShirt, bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0));
                drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 6].Value, vector, drawInfo.compBackShoulderFrame, drawInfo.colorShirt, bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0));
                drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 4].Value, vector, drawInfo.compTorsoFrame, drawInfo.colorUnderShirt, bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0));
                drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 6].Value, vector, drawInfo.compTorsoFrame, drawInfo.colorShirt, bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0));
            }
            if (drawInfo.drawFloatingTube)
            {
                List<DrawData> drawDataCache = drawInfo.DrawDataCache;
                DrawData drawData = new(TextureAssets.Extra[105].Value, vector, new Rectangle(0, 56, 40, 56), drawInfo.floatingTubeColor, bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                {
                    shader = drawInfo.cFloatingTube
                };
                drawDataCache.Add(drawData);
            }
        }

        protected static void DrawHands(ref PlayerDrawSet drawInfo)
        {
            DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 5].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorBodySkin, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
            {
                shader = drawInfo.skinDyePacked
            };
            DrawData item = drawData;
            drawInfo.DrawDataCache.Add(item);
        }
    }
}
