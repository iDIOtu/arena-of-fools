using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private int _enemySpawnCounter;
    public int EnemySpawnCounter => _enemySpawnCounter;

    private int _enemySpawned;

    private void Start()
    {
        _enemySpawned = _enemySpawnCounter;

        Spawn();
        StartCoroutine(Spawner());
    }

    private void Spawn()
    {
        GameObject enemy = Instantiate(_enemyPrefab);
        enemy.transform.position = _spawnPoint.position;

        _enemySpawned -= 1;
    }

    private IEnumerator Spawner()
    {
        while (_enemySpawned > 0)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            Spawn();
        }
    }
}
