using System.Collections.Generic;

namespace Shardion.Ether.Content.NPCs.Oddity
{
    public enum SnapDivisor
    {
        OneFour = 4,
        OneTwo = 2,
        OneOne = 1,
    }

    public class GenericSnapCapableStage : OddityStage
    {
        public SongMetadata Song { get; set; }

        private OddityTimer _beatTimer = new();
        private int _beatCount;

        private Dictionary<OddityMovement, SnapDivisor> _pendingMovements = new();
        private List<OddityMovement> _activeMovements = new();

        private readonly float _ticksPerBeat;

        public GenericSnapCapableStage(SongMetadata song)
        {
            Song = song;
            _ticksPerBeat = 60 / (song.BPM / 60);
        }

        public void Update(Oddity oddity)
        {
            Song.Update();
            _beatTimer.Ticks++;
            if (_beatTimer.Ticks >= _ticksPerBeat)
            {
                _beatTimer.Ticks = 0;
                _beatCount++;
            }

            foreach (KeyValuePair<OddityMovement, SnapDivisor> movement in _pendingMovements)
            {
                if (_beatCount % (int)movement.Value == 0 && !movement.Key.IsMovementStarted(oddity))
                {
                    movement.Key.StartMovement(oddity);
                    _activeMovements.Add(movement.Key);
                }
            }
            for (int index = 0; index < _activeMovements.Count; index++)
            {
                if (_activeMovements[index].Update(oddity))
                {
                    _activeMovements.RemoveAt(index);
                    _ = _pendingMovements.Remove(_activeMovements[index]);
                    index--;
                }
            }
        }
    }
}