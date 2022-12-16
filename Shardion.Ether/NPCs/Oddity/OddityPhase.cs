namespace VsOddity.NPCs.Oddity
{
    public class OddityPhase
    {
        public virtual string Name => "Oddity Phase";

        public OddityStage CurrentStage { get; protected set; }
        public bool IsStarting { get; protected set; }
        public bool IsStarted { get; protected set; }
        protected bool IsMainPhaseEnded { get; set; }
        public bool IsEnding { get; protected set; }
        public bool IsEnded { get; protected set; }

        public virtual OddityStage[] Stages => new OddityStage[] { new OddityStage() };
        private int _currentStageIndex = -1;

        public virtual void StartPhase(Oddity oddity)
        {
            IsStarting = true;
        }

        public virtual void EndPhase(Oddity oddity)
        {
            IsEnding = true;
        }

        public virtual bool IsPhaseStarting(Oddity oddity)
        {
            return IsStarting;
        }

        public virtual bool IsPhaseEnding(Oddity oddity)
        {
            return IsEnding;
        }

        public virtual bool IsPhaseStarted(Oddity oddity)
        {
            return IsStarted;
        }

        public virtual bool IsPhaseEnded(Oddity oddity)
        {
            return IsEnded;
        }

        public virtual bool ShouldStartPhase(Oddity oddity)
        {
            return !IsStarting && !IsStarted;
        }

        public virtual bool ShouldEndPhase(Oddity oddity)
        {
            return !IsEnding && !IsEnded && IsMainPhaseEnded;
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

        public void RunAllAI(Oddity oddity)
        {
            if (IsPhaseStarting(oddity) && !IsPhaseStarted(oddity))
            {
                StartAI(oddity);
            }
            else if (IsPhaseEnding(oddity) && !IsPhaseEnded(oddity))
            {
                EndAI(oddity);
            }
            else
            {
                AI(oddity);
            }
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
                if (CurrentStage == null)
                {
                    CurrentStage = NextStage();
                    return;
                }
                if (CurrentStage.ShouldStartStage(oddity))
                {
                    CurrentStage.StartStage(oddity);
                }
                if (CurrentStage.ShouldStopStage(oddity))
                {
                    CurrentStage.StopStage(oddity);
                }

                CurrentStage.RunAllAI(oddity);

                if (CurrentStage.IsStageStopped(oddity))
                {
                    CurrentStage = NextStage();
                }

                OnAI(oddity);
            }
        }

        public virtual bool PreEndAI(Oddity oddity)
        {
            return true;
        }

        public virtual void OnEndAI(Oddity oddity)
        {
            IsEnded = true;
            return;
        }

        public void EndAI(Oddity oddity)
        {
            if (PreEndAI(oddity))
            {
                OnEndAI(oddity);
            }
        }

        private OddityStage NextStage()
        {
            if (Stages.GetUpperBound(0) > _currentStageIndex)
            {
                if (Stages.GetValue(_currentStageIndex + 1) is OddityStage nextStage)
                {
                    _currentStageIndex++;
                    return nextStage;
                }
            }
            if (Stages.GetValue(Stages.GetLowerBound(0)) is OddityStage firstStage)
            {
                _currentStageIndex = Stages.GetLowerBound(0);
                return firstStage;
            }
            return new OddityStage();
        }
    }
}
