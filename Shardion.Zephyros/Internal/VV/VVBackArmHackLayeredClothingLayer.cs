using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria.GameContent;
using Terraria;
using Terraria.DataStructures;
using static Terraria.DataStructures.PlayerDrawLayers;

namespace Shardion.Zephyros.Internal.VV
{
    /// <remarks>
    /// Called the "Back Arm Hack" due to how it renders over the vanilla back arm.
    /// </remakrs>
    public class VVBackArmHackLayeredClothingLayer : VVLayeredClothingLayer
    {
        public override ArmorSlots ArmorSlot => ArmorSlots.Torso;
        public override PlayerLayers PlayerLayer => PlayerLayers.BackArms;

        protected override void DrawLayer(ref PlayerDrawSet drawInfo, Item layerItem)
        {
            int layerId = layerItem.bodySlot;
            //            if (layerId == -1) // TODO: figure out why -1 is being passed into this
            //            {
            //                layerId = 0; // it's as shrimple as that
            //            }
            Vector2 vector = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2);
            Vector2 value = Main.OffsetsPlayerHeadgear[drawInfo.drawPlayer.bodyFrame.Y / drawInfo.drawPlayer.bodyFrame.Height];
            value.Y -= 2f;
            vector += value * -drawInfo.playerEffect.HasFlag(SpriteEffects.FlipVertically).ToDirectionInt();
            vector.Y += drawInfo.torsoOffset;
            float bodyRotation = drawInfo.drawPlayer.bodyRotation;
            Vector2 vector2 = vector;
            Vector2 position = vector;
            Vector2 bodyVect = drawInfo.bodyVect;
            Vector2 compositeOffset_BackArm = GetBackArmCompositeOffset(ref drawInfo);
            vector2 += compositeOffset_BackArm;
            position += drawInfo.backShoulderOffset;
            bodyVect += compositeOffset_BackArm;
            float rotation = bodyRotation + drawInfo.compositeBackArmRotation;
            bool armsNeedDrawn = !drawInfo.drawPlayer.invis; //flag
            bool somethingNeedsDrawn = !drawInfo.drawPlayer.invis; //flag2
            bool wearingSomething = layerId > 0; //flag3
            bool armorShowsTorso = !drawInfo.hidesTopSkin; //flag4
            bool handsDrawn = false; //flag5
            if (wearingSomething)
            {
                Main.instance.LoadArmorBody(layerId);
                // if player is visible & armor shows arms
                armsNeedDrawn &= !drawInfo.armorHidesArms;
                if (somethingNeedsDrawn && !drawInfo.armorHidesArms)
                {
                    // draw arms
                    if (armorShowsTorso)
                    {
                        List<DrawData> drawDataCache = drawInfo.DrawDataCache;
                        DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 7].Value, vector2, drawInfo.compBackArmFrame, drawInfo.colorBodySkin, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                        {
                            shader = drawInfo.skinDyePacked
                        };
                        drawDataCache.Add(drawData);
                    }
                    // draw hands
                    if (!handsDrawn && armorShowsTorso)
                    {
                        List<DrawData> drawDataCache2 = drawInfo.DrawDataCache;
                        DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 5].Value, vector2, drawInfo.compBackArmFrame, drawInfo.colorBodySkin, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                        {
                            shader = drawInfo.skinDyePacked
                        };
                        drawDataCache2.Add(drawData);
                        handsDrawn = true;
                    }
                    // job done
                    somethingNeedsDrawn = false;
                }
                // if player is visible, draw armor arms
                if (!drawInfo.drawPlayer.invis || IsArmorDrawnWhenInvisible(layerId))
                {
                    Main.instance.LoadArmorBody(layerId);
                    Texture2D value2 = TextureAssets.ArmorBodyComposite[layerId].Value;

                    DrawData drawData2;
                    DrawData drawData;
                    if (!drawInfo.hideCompositeShoulders)
                    {
                        drawData2 = new DrawData(value2, position, drawInfo.compBackShoulderFrame, drawInfo.colorArmorBody, bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
                        {
                            shader = drawInfo.cBody
                        };
                        drawData = drawData2;
                        DrawCompositeArmorPiece(ref drawInfo, CompositePlayerDrawContext.BackShoulder, drawData2);
                    }
                    DrawPlayer_12_1_BalloonFronts(ref drawInfo);
                    drawData2 = new DrawData(value2, vector2, drawInfo.compBackArmFrame, drawInfo.colorArmorBody, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                    {
                        shader = drawInfo.cBody
                    };
                    drawData = drawData2;
                    DrawCompositeArmorPiece(ref drawInfo, CompositePlayerDrawContext.BackArm, drawData2);
                }
            }

            if (armsNeedDrawn)
            {
                if (armorShowsTorso)
                {
                    if (somethingNeedsDrawn)
                    {
                        List<DrawData> drawDataCache3 = drawInfo.DrawDataCache;
                        DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 7].Value, vector2, drawInfo.compBackArmFrame, drawInfo.colorBodySkin, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                        {
                            shader = drawInfo.skinDyePacked
                        };
                        drawDataCache3.Add(drawData);
                    }
                    if (!handsDrawn && armorShowsTorso)
                    {
                        List<DrawData> drawDataCache4 = drawInfo.DrawDataCache;
                        DrawData drawData = new(TextureAssets.Players[drawInfo.skinVar, 5].Value, vector2, drawInfo.compBackArmFrame, drawInfo.colorBodySkin, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                        {
                            shader = drawInfo.skinDyePacked
                        };
                        drawDataCache4.Add(drawData);
                        handsDrawn = true;
                    }
                }
                if (!wearingSomething)
                {
                    drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 8].Value, vector2, drawInfo.compBackArmFrame, drawInfo.colorUnderShirt, rotation, bodyVect, 1f, drawInfo.playerEffect, 0));
                    DrawPlayer_12_1_BalloonFronts(ref drawInfo);
                    drawInfo.DrawDataCache.Add(new DrawData(TextureAssets.Players[drawInfo.skinVar, 13].Value, vector2, drawInfo.compBackArmFrame, drawInfo.colorShirt, rotation, bodyVect, 1f, drawInfo.playerEffect, 0));
                }
            }
            if (drawInfo.drawPlayer.handoff > 0)
            {
                Texture2D value3 = TextureAssets.AccHandsOffComposite[drawInfo.drawPlayer.handoff].Value;
                DrawData drawData2 = new(value3, vector2, drawInfo.compBackArmFrame, drawInfo.colorArmorBody, rotation, bodyVect, 1f, drawInfo.playerEffect, 0)
                {
                    shader = drawInfo.cHandOff
                };
                DrawData drawData = drawData2;
                DrawCompositeArmorPiece(ref drawInfo, CompositePlayerDrawContext.BackArmAccessory, drawData);
            }
            if (drawInfo.drawPlayer.drawingFootball)
            {
                Main.instance.LoadProjectile(861);
                Texture2D value4 = TextureAssets.Projectile[861].Value;
                Rectangle rectangle = value4.Frame(1, 4);
                Vector2 origin = rectangle.Size() / 2f;
                Vector2 position2 = vector2 + new Vector2(drawInfo.drawPlayer.direction * -2, drawInfo.drawPlayer.gravDir * 4f);
                drawInfo.DrawDataCache.Add(new DrawData(value4, position2, rectangle, drawInfo.colorArmorBody, bodyRotation + ((float)Math.PI / 4f * drawInfo.drawPlayer.direction), origin, 0.8f, drawInfo.playerEffect, 0));
            }
        }
    }
}
