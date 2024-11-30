using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemySpawnerServices
{
    public abstract List<Enemy> GetEnemy();
}

