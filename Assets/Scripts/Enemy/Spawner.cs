using System;
using System.Data;
using System.Threading.Tasks;
using RogueLike.Actor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RogueLike.Enemy
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private EnemyTag _enemyPrefab;
        [SerializeField] private Transform _enemySpawnPointsParent;

        private Vector3[] _spawnPoints;

        void Start()
        {
            if (_enemyPrefab == null)
                throw new ConstraintException($"Has no enemy prefab at {name}");

            _spawnPoints = new Vector3[_enemySpawnPointsParent.childCount];
            
            for (int i = 0; i < _enemySpawnPointsParent.childCount; i++)
                _spawnPoints[i] = _enemySpawnPointsParent.GetChild(i).position;
        }

        public async Task SpawnEnemyWithDelay(TimeSpan delay, int count, INotifiable notifiable = null)
        {
            for (int i = 0; i < count; i++)
            {
                var enemy = SpawnEnemyInPoint(_spawnPoints[i % _spawnPoints.Length]);
                enemy.Init(notifiable);
                await Task.Delay(delay);
            }
        }

        private EnemyTag SpawnEnemyInPoint(Vector3 position)
        {
            return Instantiate(_enemyPrefab, position, Quaternion.identity);
        }
    }
}