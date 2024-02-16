using Achievements.Scripts.Concrete;
using UnityEngine;

namespace Achievements.Scripts.View
{
    public abstract class AbstractAchievementViewerItem : MonoBehaviour
    {
        public abstract void UpdateWith(AbstractAchievement achievement);
    }
}