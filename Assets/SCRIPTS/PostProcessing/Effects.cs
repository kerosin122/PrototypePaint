using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Effects : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    private PostProcessVolume _effectApproachingEnemy;
    private IEnemyDetectingServices _enemyDetecting;

    public void Inject(IEnemyDetectingServices enemyDetecting)
    {
        _enemyDetecting = enemyDetecting;
    }
    private void Start()
    {
        _effectApproachingEnemy = GetComponent<PostProcessVolume>();
    }

    private void FixedUpdate()
    {
        Enemy Enemy = _enemyDetecting.GetClosestEnemy();
        float distanceClosestEnemy = Vector2.Distance(transform.position, Enemy.transform.position);
        float distance = Mathf.InverseLerp(_maxDistance, 0, distanceClosestEnemy);
        _effectApproachingEnemy.weight = distance;
    }



}
