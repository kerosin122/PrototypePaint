using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Effects : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    private PostProcessVolume _effectApproachingEnemy;
    private EnemyDetecting _enemyDetecting;

    public void Inject(EnemyDetecting enemyDetecting)
    {
        _enemyDetecting = enemyDetecting;
    }
    private void Start()
    {
        _effectApproachingEnemy = GetComponent<PostProcessVolume>();
    }

    private void FixedUpdate()
    {
        float distance = Mathf.InverseLerp(_maxDistance, 0, _enemyDetecting.GetDistanceOfEnemyFromPlayer());
        _effectApproachingEnemy.weight = distance;
    }



}
