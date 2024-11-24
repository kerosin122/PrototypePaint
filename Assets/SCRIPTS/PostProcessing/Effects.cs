using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Effects : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    private PostProcessVolume _effectApproachingEnemy;
    private EnemyDetecting _enemyDetecting;
    private void Start()
    {
        _effectApproachingEnemy.weight = 1;
    }



}
