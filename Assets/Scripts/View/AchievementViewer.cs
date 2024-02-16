using System;
using Achievements.Scripts.Concrete;
using UnityEngine;

namespace Achievements.Scripts.View
{
    public class AchievementViewer : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField, SerializeReference] private AbstractAchievement _achievement;

        private AbstractAchievementViewerItem[] _items;

        private void Start()
        {
            _achievement = AchievementHandler.Get(_tag);
            _items = GetComponentsInChildren<AbstractAchievementViewerItem>();

            _achievement.stage += UpdateItems;
            UpdateItems();
        }

        private void UpdateItems()
        {
            foreach (var item in _items)
                item.UpdateWith(_achievement);
        }

        private void OnDestroy()
        {
            AchievementHandler.Get(_tag).stage -= UpdateItems;
        }
    }
}