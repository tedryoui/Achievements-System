using Achievements.Scripts.Concrete;
using Newtonsoft.Json;
using UnityEngine;

namespace Achievements.Scripts
{
    [JsonObject(MemberSerialization.Fields)]
    [CreateAssetMenu(fileName = "Achievement Collection", menuName = "Achievement/Collection", order = 0)]
    public class AchievementCollection : ScriptableObject
    {
        [SerializeReference] public AbstractAchievement[] Achievements;
    }
}