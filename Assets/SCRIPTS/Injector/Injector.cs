using UnityEngine;

public class Injector : MonoBehaviour
{
    [SerializeField] private MagicRockParent _rockService;
    private PaintManager _paintManager;
    [SerializeField] private EnemyDetecting _enemyDetecting;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _paintManager = new(_rockService);
        _enemyDetecting.Inject(_enemySpawner);
    }
}
