using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace Achievements.Scripts.Concrete
{
    [CreateAssetMenu(fileName = "Compound Achievement", menuName = "Achievement/Compound", order = 2)]
    public class CompoundAchievement : AbstractAchievement
    {
        [SerializeField, SerializeReference, JsonRequired] private AbstractAchievement[] _defaultStages;
        [SerializeField, SerializeReference, JsonRequired] private AbstractAchievement[] _stages;

        private AbstractAchievement[] Stages
        {
            get
            {
                if (_stages.Length != _defaultStages.Length)
                    _stages = _defaultStages.Select(Instantiate).ToArray();
                return _stages;
            }
        }

        public override string Tag => (CurrentStage() != null) ? $"{CurrentStage().Tag} {tag}" : $"{Stages.Last().Tag} {tag}";
        public override float Progress => (CurrentStage() != null) ? CurrentStage().Progress : 1.0f;
        public override AbstractAchievement ActiveReference => CurrentStage().ActiveReference;

        private AbstractAchievement CurrentStage()
        {
            var current = Stages.FirstOrDefault(x => x.state is State.Uncompleted or State.Finished);

            return current;
        }
        
        public override void Stage()
        {
            var current = CurrentStage();
            if (current == null) return;

            current.Stage();
            
            if (current.state is State.Finished)
                OnFinished();
            else
                OnStage();
        }

        public override void Complete()
        {
            var current = CurrentStage();

            if (current != null)
            {
                current.Complete();
                current = CurrentStage();

                if (current != null)
                    state = State.Uncompleted;
                else
                    state = State.Completed;
            }

            OnStage();
        }

        public override void OnFinished()
        {
            state = State.Finished;
            
            OnStage();
        }
    }
}