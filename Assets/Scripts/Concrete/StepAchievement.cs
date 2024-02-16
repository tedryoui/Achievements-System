using Achievements.Scripts.Core;
using UnityEngine;

namespace Achievements.Scripts.Concrete
{
    [CreateAssetMenu(fileName = "Step Achievement", menuName = "Achievement/Step", order = 1)]
    public class StepAchievement : AbstractAchievement
    {
        public int steps;
        public int current;

        public override float Progress => (float)current / (float)steps;
        public override AbstractAchievement ActiveReference => this;

        public override void Stage()
        {
            if (state is not State.Uncompleted) return;
            
            current++;

            if (steps == current)
                OnFinished();
            else
                OnStage();
        }

        public override void Complete()
        {
            base.Complete();

            AcquireReward();
        }

        [SerializeField] private int _coinsReward;
        public int CoinsReward => _coinsReward;
        
        protected override void AcquireReward()
        {
            Player.Instance.coins += _coinsReward;
        }
    }
}