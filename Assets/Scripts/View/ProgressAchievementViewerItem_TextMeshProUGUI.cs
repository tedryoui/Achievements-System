using Achievements.Scripts.Concrete;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Achievements.Scripts.View
{
    public class ProgressAchievementViewerItem_TextMeshProUGUI : AbstractAchievementViewerItem
    {
        [SerializeField] private TextMeshProUGUI _slider;
        
        public override void UpdateWith(AbstractAchievement achievement)
        {
            _slider.SetText(((int)(achievement.Progress * 100.0f)).ToString() + "%");
        }
    }
}