using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour, IEnemyDetectingServices
{
    private IEnemySpawnerServices _enemySpawner;
    private List<Enemy> _enemyAll;

    public void Inject(IEnemySpawnerServices enemySpawner)
    {
        _enemySpawner = enemySpawner;
        _enemyAll = _enemySpawner.GetEnemy();
    }

    public Enemy GetClosestEnemy()
    {
        float minDistance = Vector3.Distance(transform.position, _enemyAll[0].transform.position);
        Enemy closestEnemy = _enemyAll[0];
        foreach (var enemy in _enemyAll)
        {
            float distanceFromEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceFromEnemy <= minDistance)
            {
                minDistance = distanceFromEnemy;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
}
