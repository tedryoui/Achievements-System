using Achievements.Scripts.Concrete;
using UnityEngine;
using UnityEngine.UI;

namespace Achievements.Scripts.View
{
    public class CompleteAchievementViewerItem : AbstractAchievementViewerItem
    {
        [SerializeField] private Button _button;
        
        public override void UpdateWith(AbstractAchievement achievement)
        {
            if (achievement.state is AbstractAchievement.State.Finished)
            {
                _button.onClick.RemoveAllListeners();
                _button.onClick.AddListener(achievement.Complete);
            }
        }
    }
}