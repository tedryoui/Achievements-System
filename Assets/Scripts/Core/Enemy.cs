using UnityEngine;

namespace Achievements.Scripts.Core
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private string[] _achievementTriggers;
        
        public void Kill()
        {
            Player.Instance.AddKill();

            foreach (var trigger in _achievementTriggers)
                AchievementHandler.Stage(trigger);
            
            Destroy(gameObject);
        }
    }
}