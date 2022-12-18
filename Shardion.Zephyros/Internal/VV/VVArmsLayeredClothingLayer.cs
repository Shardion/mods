using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria;
using Terraria.DataStructures;
using static Terraria.DataStructures.PlayerDrawLayers;

namespace Shardion.Zephyros.Internal.VV
{
    public class VVArmsLayeredClothingLayer : VVLayeredClothingLayer
    {
        public override ArmorSlots ArmorSlot => ArmorSlots.Torso;
        public override PlayerLayers PlayerLayer => PlayerLayers.ArmOverItem;

        // 1.3 arms drawing function
        protected override void DrawLayer(ref PlayerDrawSet drawInfo, Item layerItem)
        {
            int layerId = layerItem.bodySlot;
            if (drawInfo.usesCompositeTorso)
            {
                DrawArmsLayerComposite(ref drawInfo, layerId);
            }
            else if (layerId > 0)
            {
                Main.instance.LoadArmorBody(layerId);
                Rectangle bodyFrame = drawInfo.drawPlayer.bodyFrame;
                int num = drawInfo.armorAdjust;
                bodyFrame.X += num;
                bodyFrame.Width -= num;
                if (drawInfo.drawPlayer.direction == -1)
                {
                    num = 0;
                }
                if (drawInfo.drawPlayer.invis && (layerId == 21 || layerId == 22))
                {
                    return;
                }
                DrawData item;
                if (!drawInfo.armorHidesHands && !drawInfo.drawPlayer.invis)
                {
                    _ = drawInfo.drawPlayer.body;
                    DrawData drawData;
                    if (!drawInfo.armorHidesArms)
                    {
                        drawData = new DrawData(TextureAssets.Players[drawInfo.skinVar, 7].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorBodySkin, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                        {
                            shader = drawInfo.skinDyePacked
                        };
                        item = drawData;
                        drawInfo.DrawDataCache.Add(item);
                    }
                    drawData = new DrawData(TextureAssets.Players[drawInfo.skinVar, 9].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorBodySkin, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                    {
                        shader = drawInfo.skinDyePacked
                    };
                    item = drawData;
                    drawInfo.DrawDataCache.Add(item);
                }
                item = new DrawData(TextureAssets.ArmorArm[layerId].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)) + num, (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), bodyFrame, drawInfo.colorArmorBody, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                {
                    shader = drawInfo.cBody
                };
                drawInfo.DrawDataCache.Add(item);
                if (drawInfo.armGlowMask != -1)
                {
                    item = new DrawData(TextureAssets.GlowMask[drawInfo.armGlowMask].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)) + num, (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), bodyFrame, drawInfo.armGlowColor, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                    {
                        shader = drawInfo.cBody
                    };
                    drawInfo.DrawDataCache.Add(item);
                }
                if (layerId == 205)
                {
                    Color color = new(100, 100, 100, 0);
                    ulong seed = (ulong)(drawInfo.drawPlayer.miscCounter / 4);
                    int num2 = 4;
                    for (int i = 0; i < num2; i++)
                    {
                        float num3 = Utils.RandomInt(ref seed, -10, 11) * 0.2f;
                        float num4 = Utils.RandomInt(ref seed, -10, 1) * 0.15f;
                        item = new DrawData(TextureAssets.GlowMask[240].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)) + num, (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2((drawInfo.drawPlayer.bodyFrame.Width / 2) + num3, (drawInfo.drawPlayer.bodyFrame.Height / 2) + num4), bodyFrame, color, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                        {
                            shader = drawInfo.cBody
                        };
                        drawInfo.DrawDataCache.Add(item);
                    }
                }
            }
            else if (!drawInfo.drawPlayer.invis)
            {
                DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 7].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorBodySkin, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                {
                    shader = drawInfo.skinDyePacked
                };
                DrawData item = drawData;
                drawInfo.DrawDataCache.Add(item);
                item = new DrawData(TextureAssets.Players[drawInfo.skinVar, 8].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorUnderShirt, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0);
                drawInfo.DrawDataCache.Add(item);
                item = new DrawData(TextureAssets.Players[drawInfo.skinVar, 13].Value, new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2), drawInfo.drawPlayer.bodyFrame, drawInfo.colorShirt, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0);
                drawInfo.DrawDataCache.Add(item);
            }
        }

        protected void DrawArmsLayerComposite(ref PlayerDrawSet drawInfo, int layerId)
        {
            Vector2 vector = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2);
            Vector2 value = Main.OffsetsPlayerHeadgear[drawInfo.drawPlayer.bodyFrame.Y / drawInfo.drawPlayer.bodyFrame.Height];
            value.Y -= 2f;
            vector += value * -drawInfo.playerEffect.HasFlag(SpriteEffects.FlipVertically).ToDirectionInt();
            float bodyRotation = drawInfo.drawPlayer.bodyRotation;
            float rotation = drawInfo.drawPlayer.bodyRotation + drawInfo.compositeFrontArmRotation;
            Vector2 bodyVect = drawInfo.bodyVect;
            Vector2 compositeOffset_FrontArm = GetFrontArmCompositeOffset(ref drawInfo);
            bodyVect += compositeOffset_FrontArm;
            vector += compositeOffset_FrontArm;
            Vector2 position = vector + drawInfo.frontShoulderOffset;
            if (drawInfo.compFrontArmFrame.X / drawInfo.compFrontArmFrame.Width >= 7)
            {
                vector += new Vector2((!drawInfo.playerEffect.HasFlag(SpriteEffects.FlipHorizontally)) ? 1 : (-1), (!drawInfo.playerEffect.HasFlag(SpriteEffects.FlipVertically)) ? 1 : (-1));
            }
            _ = drawInfo.drawPlayer.invis;
            bool num5 = layerId > 0;
            int num2 = drawInfo.compShoulderOverFrontArm ? 1 : 0;
            bool flag = !drawInfo.hidesTopSkin;
            if (num5)
            {
                Main.instance.LoadArmorBody(layerId);
                if (!drawInfo.drawPlayer.invis)
                {
                    Texture2D value2 = TextureAssets.ArmorBodyComposite[layerId].Value;
                    for (int i = 0; i < 2; i++)
                    {
                        if (!drawInfo.drawPlayer.invis && i == num2 && flag)
                        {
                            if (!drawInfo.armorHidesArms)
                            {
                                List<DrawData> drawDataCache = drawInfo.DrawDataCache;
                                DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 7].Value, vector, drawInfo.compFrontArmFrame, drawInfo.colorBodySkin, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                                {
                                    shader = drawInfo.skinDyePacked
                                };
                                drawDataCache.Add(drawData);
                            }
                            if (!drawInfo.armorHidesHands) // lol??? lmao???
                            {
                                List<DrawData> drawDataCache2 = drawInfo.DrawDataCache;
                                DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 9].Value, vector, drawInfo.compFrontArmFrame, drawInfo.colorBodySkin, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                                {
                                    shader = drawInfo.skinDyePacked
                                };
                                drawDataCache2.Add(drawData);
                            }
                        }
                        if (i == num2 && !drawInfo.hideCompositeShoulders)
                        {
                            DrawData drawData2 = new(value2, position, drawInfo.compFrontShoulderFrame, drawInfo.colorArmorBody, bodyRotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                            {
                                shader = drawInfo.cBody
                            };
                            DrawData drawData = drawData2;
                            DrawCompositeArmorPiece(ref drawInfo, CompositePlayerDrawContext.FrontShoulder, drawData);
                        }
                        if (i == num2)
                        {
                            DrawData drawData2 = new(value2, vector, drawInfo.compFrontArmFrame, drawInfo.colorArmorBody, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                            {
                                shader = drawInfo.cBody
                            };
                            DrawData drawData = drawData2;
                            DrawCompositeArmorPiece(ref drawInfo, CompositePlayerDrawContext.FrontArm, drawData);
                        }
                    }
                }
            }
            else if (!drawInfo.drawPlayer.invis)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == num2)
                    {
                        if (flag)
                        {
                            List<DrawData> drawDataCache3 = drawInfo.DrawDataCache;
                            DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 7].Value, position, drawInfo.compFrontShoulderFrame, drawInfo.colorBodySkin, bodyRotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                            {
                                shader = drawInfo.skinDyePacked
                            };
                            drawDataCache3.Add(drawData);
                        }
                        drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 8].Value, position, drawInfo.compFrontShoulderFrame, drawInfo.colorUnderShirt, bodyRotation, bodyVect, 1f, drawInfo.playerEffect, 0));
                        drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 13].Value, position, drawInfo.compFrontShoulderFrame, drawInfo.colorShirt, bodyRotation, bodyVect, 1f, drawInfo.playerEffect, 0));
                        drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 6].Value, position, drawInfo.compFrontShoulderFrame, drawInfo.colorShirt, bodyRotation, bodyVect, 1f, drawInfo.playerEffect, 0));
                        if (drawInfo.drawPlayer.head == 269)
                        {
                            Vector2 position2 = drawInfo.helmetOffset + new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.headPosition + drawInfo.headVect;
                            DrawData item = new(TextureAssets.Extra[214].Value, position2, drawInfo.drawPlayer.bodyFrame, drawInfo.colorArmorHead, drawInfo.drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0)
                            {
                                shader = drawInfo.cHead
                            };
                            drawInfo.DrawDataCache.Add(item);
                            item = new DrawData(TextureAssets.GlowMask[308].Value, position2, drawInfo.drawPlayer.bodyFrame, drawInfo.headGlowColor, drawInfo.drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0)
                            {
                                shader = drawInfo.cHead
                            };
                            drawInfo.DrawDataCache.Add(item);
                        }
                    }
                    if (j == num2)
                    {
                        if (flag)
                        {
                            List<DrawData> drawDataCache4 = drawInfo.DrawDataCache;
                            DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 7].Value, vector, drawInfo.compFrontArmFrame, drawInfo.colorBodySkin, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                            {
                                shader = drawInfo.skinDyePacked
                            };
                            drawDataCache4.Add(drawData);
                        }
                        drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 8].Value, vector, drawInfo.compFrontArmFrame, drawInfo.colorUnderShirt, rotation, bodyVect, 1f, drawInfo.playerEffect, 0));
                        drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 13].Value, vector, drawInfo.compFrontArmFrame, drawInfo.colorShirt, rotation, bodyVect, 1f, drawInfo.playerEffect, 0));
                        drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 6].Value, vector, drawInfo.compFrontArmFrame, drawInfo.colorShirt, rotation, bodyVect, 1f, drawInfo.playerEffect, 0));
                    }
                }
            }
            if (drawInfo.drawPlayer.handon > 0)
            {
                Texture2D value3 = TextureAssets.AccHandsOnComposite[drawInfo.drawPlayer.handon].Value;
                DrawData drawData2 = new(value3, vector, drawInfo.compFrontArmFrame, drawInfo.colorArmorBody, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                {
                    shader = drawInfo.cHandOn
                };
                DrawData drawData = drawData2;
                DrawCompositeArmorPiece(ref drawInfo, CompositePlayerDrawContext.FrontArmAccessory, drawData);
            }
        }
    }
}
