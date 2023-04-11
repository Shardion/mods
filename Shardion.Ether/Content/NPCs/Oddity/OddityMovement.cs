namespace Shardion.Ether.Content.NPCs.Oddity
{
    public class OddityMovement
    {
        public virtual string Name => "Oddity Movement";

        public bool IsStarting { get; protected set; }
        public bool IsStarted { get; protected set; }
        public bool IsRunning { get; protected set; }
        public bool IsStopping { get; protected set; }
        public bool IsStopped { get; protected set; }

        public virtual void StartMovement(Oddity oddity)
        {
            IsStarting = true;
        }

        public virtual void StopMovement(Oddity oddity)
        {
            IsStopping = true;
        }

        public virtual bool IsMovementStarted(Oddity oddity)
        {
            return IsStarted;
        }

        public virtual bool IsMovementStopped(Oddity oddity)
        {
            return IsStopped;
        }

        public virtual bool IsMovementStarting(Oddity oddity)
        {
            return IsStarting;
        }

        public virtual bool IsMovementStopping(Oddity oddity)
        {
            return IsStopping;
        }

        public virtual bool ShouldStartMovement(Oddity oddity)
        {
            return !IsStarting && !IsStarted && !IsRunning;
        }

        public virtual bool ShouldStopMovement(Oddity oddity)
        {
            return !IsStopping && !IsStopped && !IsRunning;
        }

        public virtual void StartAI(Oddity oddity)
        {
        }

        public virtual void AI(Oddity oddity)
        {
        }

        public virtual void StopAI(Oddity oddity)
        {
        }

        public bool Update(Oddity oddity)
        {
            if (IsMovementStopped(oddity))
            {
                return true;
            }

            if (IsMovementStarting(oddity) && !IsMovementStarted(oddity))
            {
                StartAI(oddity);
            }
            else if (IsMovementStopping(oddity))
            {
                StopAI(oddity);
            }
            else
            {
                AI(oddity);
            }

            return false;
        }
    }
}
