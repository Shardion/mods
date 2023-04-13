using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Shardion.Ether.Content.NPCs.Oddity.Phases;

namespace Shardion.Ether.Content.NPCs.Oddity
{
    public class Oddity : EtherNPC
    {
        public virtual OddityPhase[] Phases => new OddityPhase[] { new SpawnPhase(), new FirstPhase() };
        private OddityPhase _currentPhase = new SpawnPhase();
        private int _currentPhaseIndex = -1;

        private Texture2D? _oddityRingTexture = null;
        private float _oddityRingRotation;
        private static readonly Color _oddityRingColor = new(255, 255, 255);

        public override void SetStaticDefaults()
        {
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCDebuffImmunityData debuffData = new()
            {
                SpecificallyImmuneTo = new int[] {
                       BuffID.Confused
                }
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
        }

        public override void SetDefaults()
        {
            NPC.width = 256;
            NPC.height = 256;
            NPC.damage = 222222;
            NPC.defense = 222222;
            NPC.lifeMax = 1000000;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0;
            NPC.boss = true;
            if (!Main.dedServ)
            {
                // TODO: should be MMM but I wanted funny testing music
                Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/SuperGhostbustersDeluxeFullAlbum");
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                   new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
                   new FlavorTextBestiaryInfoElement("The ultimate master of weaponry, to whom there are no superiors. Reawakened 3 years after a tragedy for a reason unknown.")
               });
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 drawPosition, Color lightColor)
        {
            if (_oddityRingTexture == null)
            {
                _oddityRingTexture = ModContent.Request<Texture2D>("ShardionsOddEncounter/Assets/NPCs/Oddity/Ring", AssetRequestMode.ImmediateLoad).Value;
            }
            // Dear reader: You have no clue how much pain and suffering it took to write this line.
            spriteBatch.Draw(_oddityRingTexture, NPC.Center - drawPosition + new Vector2(0f, NPC.gfxOffY), _oddityRingTexture.Bounds, _oddityRingColor, _oddityRingRotation, _oddityRingTexture.Size() / 2, 1f, SpriteEffects.None, 0);
            return true;
        }

        public override void AI()
        {
            EtherGlobalNPC.Oddity = NPC.whoAmI;

            if (!SkyManager.Instance["VsOddity:Oddity"].IsActive())
            {
                _ = SkyManager.Instance.Activate("VsOddity:Oddity");
            }

            if (_currentPhase == null)
            {
                _currentPhase = NextPhase();
                return;
            }
            if (_currentPhase.ShouldStartPhase(this))
            {
                _currentPhase.StartPhase(this);
            }
            if (_currentPhase.ShouldEndPhase(this))
            {
                _currentPhase.EndPhase(this);
            }

            _currentPhase.RunAllAI(this);

            if (_currentPhase.IsPhaseEnded(this))
            {
                _currentPhase = NextPhase();
            }

            _oddityRingRotation += 0.05f;

            return;
        }

        private OddityPhase NextPhase()
        {
            if (Phases.GetUpperBound(0) > _currentPhaseIndex)
            {
                if (Phases.GetValue(_currentPhaseIndex + 1) is OddityPhase nextPhase)
                {
                    _currentPhaseIndex++;
                    Main.NewText("entering phase " + Phases[_currentPhaseIndex].Name);
                    return nextPhase;
                }
            }
            if (Phases.GetValue(Phases.GetLowerBound(0)) is OddityPhase firstPhase)
            {
                _currentPhaseIndex = Phases.GetLowerBound(0);
                Main.NewText("entering phase " + Phases[_currentPhaseIndex].Name);
                return firstPhase;
            }
            return new OddityPhase();
        }
    }
}
