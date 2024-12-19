using System.Collections;
using UnityEngine;

public class CustomPointEffector : MonoBehaviour
{
    private IEnemyDetectingServices _enemyDetecting;
    public void Inject(IEnemyDetectingServices enemyDetecting)
    {
        _enemyDetecting = enemyDetecting;
    }

    public void EnableEffector(Vector3 position)
    {
        _enemyDetecting.GetClosestEnemy();
        StartCoroutine(MovingGameObject(_enemyDetecting.GetClosestEnemy(), position));
    }

    private IEnumerator MovingGameObject(Enemy enemy, Vector3 pos)
    {
        // enemy.transform.Translate(pos);
        yield return null;
    }


}
