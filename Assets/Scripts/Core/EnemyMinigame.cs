using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Achievements.Scripts.Core
{
    public class EnemyMinigame : MonoBehaviour
    {
        [SerializeField] private float _timer;
        [SerializeField] private Enemy _enemyPrefab;

        private float _crrTimer;

        private void Awake()
        {
            _crrTimer = 0.0f;
        }

        private void Update()
        {
            _crrTimer += Time.deltaTime;

            if (_crrTimer >= _timer)
            {
                InstantiateEnemy();
                _crrTimer = 0.0f;
            }
        }

        private void InstantiateEnemy()
        {
            var enemy = Instantiate(_enemyPrefab, transform);

            var sizeDelta = (transform as RectTransform).sizeDelta / 2.0f;

            var spawnX = Random.Range(-sizeDelta.x, sizeDelta.x);
            var spawnY = Random.Range(-sizeDelta.y, sizeDelta.y);

            enemy.transform.position = transform.position + new Vector3(spawnX, spawnY, 0.0f);
        }
    }
}