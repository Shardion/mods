using Shardion.Ether.Content.NPCs.Oddity.Stages.FirstPhase;

namespace Shardion.Ether.Content.NPCs.Oddity.Phases
{
    public class FirstPhase : OddityPhase
    {
        public override string Name => "First Phase";
        public override OddityStage[] Stages => new OddityStage[] { new LightInDescendingDarknessStage() };

        public override bool ShouldEndPhase(Oddity oddity)
        {
            return base.ShouldEndPhase(oddity) && IsHalfHealth(oddity);
        }

        private static bool IsHalfHealth(Oddity oddity)
        {
            return oddity.NPC.GetLifePercent() <= 50.0;
        }
    }
}
