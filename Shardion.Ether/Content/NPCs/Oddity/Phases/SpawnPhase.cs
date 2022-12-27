using Terraria;

namespace Shardion.Ether.Content.NPCs.Oddity.Phases
{
    public class SpawnPhase : OddityPhase
    {
        public override string Name => "Spawn Phase";
        public override OddityStage[] Stages => new OddityStage[] { new OddityStage() };

        public override void OnAI(Oddity oddity)
        {
            Main.NewText("who's this guardian mf");
            IsMainPhaseEnded = true;
        }
    }
}
