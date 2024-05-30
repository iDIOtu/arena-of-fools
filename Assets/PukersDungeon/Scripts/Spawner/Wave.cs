using System.Linq;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _enemySpawners;

    public int GetTotalEnemyCount()
    {
        return _enemySpawners.Sum(spawner => spawner.EnemySpawnCounter);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}