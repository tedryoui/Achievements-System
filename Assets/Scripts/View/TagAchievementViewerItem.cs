using Achievements.Scripts.Concrete;
using TMPro;
using UnityEngine;

namespace Achievements.Scripts.View
{
    public class TagAchievementViewerItem : AbstractAchievementViewerItem
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public override void UpdateWith(AbstractAchievement achievement)
        {
            _text.SetText(achievement.Tag);
        }
    }
}