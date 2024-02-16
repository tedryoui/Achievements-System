using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Achievements.Scripts.Core
{
    public class Player : MonoBehaviour
    {
        #region Singleton

        private static Player _instance;

        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<Player>();

                    if (_instance == null)
                        throw new Exception($"Scene does not contain any object of type {nameof(Player)}");
                }

                return _instance;
            }
        }

        private void SingletonAwake()
        {
            _instance = this;
        }
        
        #endregion
        
        public int coins;
        public Sprite coinsIcon;

        public int kills;

        private void Awake()
        {
            SingletonAwake();
        }

        public void AddKill(int amount = 1)
        {
            kills += amount;
        }
    }
}