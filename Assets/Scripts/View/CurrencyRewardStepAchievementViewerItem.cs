using System;
using Achievements.Scripts.Concrete;
using Achievements.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Achievements.Scripts.View
{
    public class CurrencyRewardStepAchievementViewerItem : AbstractAchievementViewerItem
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;
        
        public override void UpdateWith(AbstractAchievement achievement)
        {
            var activeReference = achievement.ActiveReference;

            if (activeReference is StepAchievement stepAchievement)
            {
                _image.sprite = Player.Instance.coinsIcon;
                _text.SetText(stepAchievement.CoinsReward.ToString());
            }
        }
    }
}