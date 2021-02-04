using System;
using System.Data;
using System.Threading.Tasks;
using RogueLike.Actor;
using TMPro;
using UnityEngine;

namespace RogueLike.Enemy
{
    [RequireComponent(typeof(Spawner))]
    [RequireComponent(typeof(PortalSpawner))]
    public class Waves : MonoBehaviour, INotifiable
    {
        [SerializeField] private int enemyCountAtThisWawe = 5;
        [SerializeField] private int enemyIncrement = 5;
        [SerializeField] private int delayToSpawnEnemyInSeconds = 1;
        [SerializeField] private int delayToStartWaveInSeconds = 15;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private Transform portalSpawnpoint;

        private Spawner _enemySpawner;
        private PortalSpawner _portalSpawner;
        private int _currentEnemyCount;
        private int _currentWave;
        
        private void Awake()
        {
            _enemySpawner = GetComponent<Spawner>();
            _portalSpawner = GetComponent<PortalSpawner>();
            _currentEnemyCount = enemyCountAtThisWawe;
            if (timerText == null)
                throw new ConstraintException($"Has no {nameof(timerText)} at {name}");
            if (portalSpawnpoint == null)
                throw new ConstraintException($"Has no {nameof(portalSpawnpoint)} at {name}");
            
            StartWave();
        }

        public void Notify()
        {
            _currentEnemyCount--;
            if (_currentEnemyCount <= 0)
            {
                enemyCountAtThisWawe += enemyIncrement;
                WaveBehaviour();
            }
        }

        private async Task StartWave()
        {
            _currentWave++;
            await DelayToStartWave();
            _enemySpawner.SpawnEnemyWithDelay(delayToSpawnEnemyInSeconds.Seconds(), enemyCountAtThisWawe, this);
        }

        private void WaveBehaviour()
        {
            if (_currentWave != 0 && _currentWave % 15 == 0)
            {
                _portalSpawner.Spawn(portalSpawnpoint.position);                
                return;
            }

            if (_currentWave != 0 && _currentWave % 10 == 0)
            {
                StartBossWave();
                return;
            }

            StartWave();
        }

        private void StartBossWave()
        {
            
        }
        
        private async Task DelayToStartWave()
        {
            for (int i = delayToStartWaveInSeconds; i > 0; i--)
            {
                timerText.text = $"{i} seconds to start";
                await Task.Delay(1.Seconds());
            }

            timerText.text = String.Empty;
        }
    }
}