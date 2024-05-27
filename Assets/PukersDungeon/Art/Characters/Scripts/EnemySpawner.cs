using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private float _timeToSpawn;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private void Spawn()
    {
        GameObject enemy = Instantiate(_enemyPrefab[0]);
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            Spawn();
        }
    }
}
