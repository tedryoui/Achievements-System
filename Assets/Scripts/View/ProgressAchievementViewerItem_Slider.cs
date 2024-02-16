using Achievements.Scripts.Concrete;
using UnityEngine;
using UnityEngine.UI;

namespace Achievements.Scripts.View
{
    public class ProgressAchievementViewerItem_Slider : AbstractAchievementViewerItem
    {
        [SerializeField] private Slider _slider;
        
        public override void UpdateWith(AbstractAchievement achievement)
        {
            _slider.value = achievement.Progress;
        }
    }
}