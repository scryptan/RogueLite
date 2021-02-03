using System;
using System.Data;
using System.Threading.Tasks;
using RogueLike.Actor;
using TMPro;
using UnityEngine;

namespace RogueLike.Enemy
{
    [RequireComponent(typeof(Spawner))]
    public class Waves : MonoBehaviour, INotifiable
    {
        [SerializeField] private int _enemyCountAtThisWawe = 5;
        [SerializeField] private int _enemyIncrement = 5;
        [SerializeField] private int _delayToSpawnEnemyInSeconds = 1;
        [SerializeField] private int _delayToStartWaveInSeconds = 15;
        [SerializeField] private TMP_Text _timerText;

        private Spawner _enemySpawner;
        private int _currentEnemyCount;

        private void Awake()
        {
            _enemySpawner = GetComponent<Spawner>();
            _currentEnemyCount = _enemyCountAtThisWawe;
            if (_timerText == null)
                throw new ConstraintException($"Has no text at {name}");
            StartWave();
        }

        public void Notify()
        {
            _currentEnemyCount--;
            if (_currentEnemyCount <= 0)
            {
                _enemyCountAtThisWawe += _enemyIncrement;
                StartWave();
            }
        }

        private async Task StartWave()
        {
            await DelayToStartWave();
            _enemySpawner.SpawnEnemyWithDelay(_delayToSpawnEnemyInSeconds.Seconds(), _enemyCountAtThisWawe, this);
        }

        private async Task DelayToStartWave()
        {
            for (int i = _delayToStartWaveInSeconds; i > 0; i--)
            {
                _timerText.text = $"{i} seconds to start";
                await Task.Delay(1.Seconds());
            }

            _timerText.text = String.Empty;
        }
    }
}