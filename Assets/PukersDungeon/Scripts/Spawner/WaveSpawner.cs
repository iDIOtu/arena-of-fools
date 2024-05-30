using System;
using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Wave[] _waves;
    [SerializeField] private float _delayBetweenWaves;

    public static int _enemiesLeftToSpawn;
    private int _currentWaveIndex = 0;
    private bool _isTransitioningToNextWave = true;

    public event Action<int> WaveChanged;
    public event Action GameIsWon;

    private void OnEnable()
    {
        Enemy.EnemyDied += OnDeath;
    }

    private void OnDisable()
    {
        Enemy.EnemyDied -= OnDeath;
    }

    private void Start()
    {
        WaveChanged?.Invoke(_currentWaveIndex);
        SpawnWave();
    }

    private void Update()
    {
        if (_enemiesLeftToSpawn == 0 && _isTransitioningToNextWave)
        {
            SpawnNextWave();
        }
    }

    private void OnDeath()
    {
        _enemiesLeftToSpawn--;
    }

    private void SpawnWave()
    {
        _waves[_currentWaveIndex].Enable();

        _enemiesLeftToSpawn = _waves[_currentWaveIndex].GetTotalEnemyCount();
    }

    private void SpawnNextWave()
    {
        _waves[_currentWaveIndex].Disable();

        _currentWaveIndex++;

        if (_currentWaveIndex == _waves.Length)
        {
            GameIsWon?.Invoke();
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(DelayBeforeNextWaveCoroutine());
        }
    }

    private IEnumerator DelayBeforeNextWaveCoroutine()
    {
        _isTransitioningToNextWave = false;

        WaveChanged?.Invoke(_currentWaveIndex);

        yield return new WaitForSeconds(_delayBetweenWaves);
        SpawnWave();

        _isTransitioningToNextWave = true;
    }
}