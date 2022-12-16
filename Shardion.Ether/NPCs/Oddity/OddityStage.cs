namespace VsOddity.NPCs.Oddity
{
    public class OddityStage
    {
        public virtual string Name => "Oddity Stage";
        public bool IsStarting { get; protected set; }
        public bool IsStarted { get; protected set; }
        public bool IsRunning { get; protected set; }
        public bool IsStopping { get; protected set; }
        public bool IsStopped { get; protected set; }

        public virtual void StartStage(Oddity oddity)
        {
            IsStarting = true;
        }

        public virtual void StopStage(Oddity oddity)
        {
            IsStopping = true;
        }

        public virtual bool IsStageStarted(Oddity oddity)
        {
            return IsStarted;
        }

        public virtual bool IsStageStopped(Oddity oddity)
        {
            return IsStopped;
        }

        public virtual bool IsStageStarting(Oddity oddity)
        {
            return IsStarting;
        }

        public virtual bool IsStageStopping(Oddity oddity)
        {
            return IsStopping;
        }

        public virtual bool ShouldStartStage(Oddity oddity)
        {
            return !IsStarting && !IsStarted && !IsRunning;
        }

        public virtual bool ShouldStopStage(Oddity oddity)
        {
            return !IsStopping && !IsStopped && !IsRunning;
        }

        public virtual bool PreStartAI(Oddity oddity)
        {
            return true;
        }

        public virtual void OnStartAI(Oddity oddity)
        {
            IsStarted = true;
            return;
        }

        public void StartAI(Oddity oddity)
        {
            if (PreStartAI(oddity))
            {
                OnStartAI(oddity);
            }
        }

        public virtual bool PreAI(Oddity oddity)
        {
            return true;
        }

        public virtual void OnAI(Oddity oddity)
        {
            return;
        }

        public void AI(Oddity oddity)
        {
            if (PreAI(oddity))
            {
                OnAI(oddity);
            }
        }

        public virtual bool PreStopAI(Oddity oddity)
        {
            return true;
        }

        public virtual void OnStopAI(Oddity oddity)
        {
            IsStopped = true;
            return;
        }

        public void StopAI(Oddity oddity)
        {
            if (PreStopAI(oddity))
            {
                OnStopAI(oddity);
            }
        }

        public void RunAllAI(Oddity oddity)
        {
            if (IsStageStarting(oddity) && !IsStageStarted(oddity))
            {
                StartAI(oddity);
            }
            else if (IsStageStopping(oddity) && !IsStageStopped(oddity))
            {
                StopAI(oddity);
            }
            else
            {
                AI(oddity);
            }
        }
    }
}
