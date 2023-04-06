using System;

namespace Shardion.Zephyros.Common.Utilities
{
    /// <summary>
    /// A struct that converts between ticks, seconds, and minutes.
    /// Setting seconds or minutes rounds the resulting ticks value to the nearest integer.
    /// </summary>
    public class Timer
    {
        /// <summary>The number of ticks counted.</summary>
        public int Ticks { get; set; }

        /// <summary>The number of ticks counted, divided into seconds.</summary>
        public double Seconds
        {
            get => Ticks / 60;
            set => Ticks = Convert.ToInt32(value * 60);
        }

        /// <summary>The number of ticks counted, divided into minutes.</summary>
        public double Minutes
        {
            get => Seconds / 60;
            set => Seconds = value * 60;
        }

        public Timer(int ticks = 0)
        {
            Ticks = ticks;
        }
    }
}
