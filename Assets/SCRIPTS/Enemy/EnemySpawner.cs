using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private List<Enemy> _enemyAll = new();

    private void Awake()
    {
        foreach (var enemy in GetComponentsInChildren<Enemy>())
        {
            _enemyAll.Add(enemy);
        }
    }

    public List<Enemy> GetEnemy()
    {
        return _enemyAll;
    }
}
