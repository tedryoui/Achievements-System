using Achievements.Scripts.Concrete;
using UnityEngine;

namespace Achievements.Scripts.View
{
    public class ActiveAchievementViewerItem : AbstractAchievementViewerItem
    {
        [SerializeField] private AbstractAchievement.State activeState;
        
        public override void UpdateWith(AbstractAchievement achievement)
        {
            gameObject.SetActive(achievement.state == activeState);
        }
    }
}