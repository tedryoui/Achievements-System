using System;
using Achievements.Scripts.Core;
using Newtonsoft.Json;
using UnityEngine;

namespace Achievements.Scripts.Concrete
{
    public abstract class AbstractAchievement : ScriptableObject
    {
        public enum State { Completed, Finished, Uncompleted }
        
        public string tag;
        public State state;

        public event Action stage;

        public virtual string Tag => tag;
        public abstract float Progress { get; }

        [JsonIgnore] public abstract AbstractAchievement ActiveReference { get; }

        public abstract void Stage();

        public virtual void Complete()
        {
            state = State.Completed;
            
            OnStage();
        }
        
        public virtual void OnFinished()
        {
            state = State.Finished;
            
            OnStage();
        }

        public virtual void OnStage()
        {
            stage?.Invoke();
        }

        public void ClearActions()
        {
            stage = delegate() { };
        }

        protected virtual void AcquireReward()
        {
        }
    }
}