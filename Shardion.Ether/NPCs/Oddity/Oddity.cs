using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Shardion.Ether.NPCs.Oddity.Phases;

namespace Shardion.Ether.NPCs.Oddity
{
    public class Oddity : ModNPC
    {
        public virtual OddityPhase[] Phases => new OddityPhase[] { new SpawnPhase(), new FirstPhase() };
        private OddityPhase _currentPhase = new SpawnPhase();
        private int _currentPhaseIndex = -1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oddity");
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
            NPC.width = 100;
            NPC.height = 100;
            NPC.damage = 222222;
            NPC.defense = 222222;
            NPC.lifeMax = 1000000;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.boss = true;
            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/WorldFragments");
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                   new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
                   new FlavorTextBestiaryInfoElement("The ultimate master of weaponry, to whom there are no superiors. Reawakened 3 years after a tragedy for a reason unknown.")
               });
        }

        public override void AI()
        {
            VsOddityGlobalNPC.Oddity = NPC.whoAmI;

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
