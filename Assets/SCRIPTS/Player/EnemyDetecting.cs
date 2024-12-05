using System;
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

    public float GetDistanceOfEnemyFromPlayer()
    {
        float minDistance = Vector3.Distance(transform.position, _enemyAll[0].transform.position);
        foreach (var enemy in _enemyAll)
        {
            float distanceFromEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceFromEnemy <= minDistance)
            {
                minDistance = distanceFromEnemy;
            }
        }
        return minDistance;
    }
}
