using System;

namespace VsOddity.NPCs.Oddity
{
    public class OddityTimer
    {
        public int Ticks { get; set; }
        public double Seconds { get => Ticks / 60d; set => Ticks = Convert.ToInt32(value * 60d); }
    }
}