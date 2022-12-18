using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Shardion.Ether.Projectiles.Visual;

namespace Shardion.Ether.NPCs.Oddity.Stages.FirstPhase
{
    public class LightInDescendingDarknessStage : OddityStage
    {
        public override string Name => "Light In Descending Darkness";
        private readonly OddityTimer _attackTimer = new();
        private int _timesAttacked;
        private bool _doneStarting;
        private bool _readyToEnd;
        private Projectile? _ultimateTruth;
        private Vector2 _ultimateTruthPosition;

        public override bool IsStageStarted(Oddity oddity)
        {
            return _doneStarting;
        }

        public override void OnStartAI(Oddity oddity)
        {
            if (!_doneStarting)
            {
                _ultimateTruthPosition.X = oddity.NPC.position.X - oddity.NPC.Size.X;
                _ultimateTruthPosition.Y = oddity.NPC.position.Y - (oddity.NPC.Size.Y / 2) + 18;
                _ultimateTruth = Projectile.NewProjectileDirect(oddity.NPC.GetSource_FromAI(), _ultimateTruthPosition, Vector2.Zero, ModContent.GetInstance<UltimateTruth>().Type, 0, 0, oddity.NPC.whoAmI);
            }
            _doneStarting = true;
        }

        public override void OnAI(Oddity oddity)
        {
            _ultimateTruthPosition.X = oddity.NPC.position.X - oddity.NPC.Size.X;
            _ultimateTruthPosition.Y = oddity.NPC.position.Y - (oddity.NPC.Size.Y / 2) + 18;
            if (_ultimateTruth != null)
            {
                _ultimateTruth.position = _ultimateTruthPosition;
            }
            oddity.NPC.TargetClosest();

            if ((_attackTimer.Seconds % 1.0d) == 0.0d)
            {
                Main.NewText($"seconds: {_attackTimer.Seconds}, ticks: {_attackTimer.Ticks}");
                if (_timesAttacked >= 10)
                {
                    _readyToEnd = true;
                }
                else
                {
                    _timesAttacked++;
                }
            }

            _attackTimer.Ticks++;
            return;
        }

        public override bool ShouldStopStage(Oddity oddity)
        {
            return base.ShouldStopStage(oddity) && _readyToEnd;
        }
    }
}
