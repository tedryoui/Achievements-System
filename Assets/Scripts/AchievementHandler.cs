using System;
using System.Linq;
using Achievements.Scripts.Concrete;
using Newtonsoft.Json;
using UnityEngine;

namespace Achievements.Scripts
{
    public class AchievementHandler : MonoBehaviour
    {
        private static AchievementHandler _instance;

        [SerializeField] private AchievementCollection _collection;
        [SerializeField, SerializeReference, HideInInspector] private AbstractAchievement[] _achievements;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                
                InitializeAchievements();
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private void InitializeAchievements()
        {
            if (_achievements.Length != _collection.Achievements.Length)
                _achievements = _collection.Achievements.Select(Instantiate).ToArray();
        }

        public static void Stage(string tag)
        {
            var search = _instance._achievements.Where(x => x.tag.Equals(tag));

            foreach (var achievement in search)
                achievement.Stage();                
        }

        public static AbstractAchievement Get(string tag)
        {
            var search = _instance._achievements.FirstOrDefault(x => x.tag.Equals(tag));

            return search;
        }
    }
}