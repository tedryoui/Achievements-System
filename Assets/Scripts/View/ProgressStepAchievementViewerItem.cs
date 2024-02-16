using System;
using Achievements.Scripts.Concrete;
using TMPro;
using UnityEngine;

namespace Achievements.Scripts.View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ProgressStepAchievementViewerItem : AbstractAchievementViewerItem
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public override void UpdateWith(AbstractAchievement achievement)
        {
            var active = achievement.ActiveReference;
            
            if (active is StepAchievement stepAchievement)
            {
                _text.SetText($"{stepAchievement.current}/{stepAchievement.steps}");
            }
        }
    }
}