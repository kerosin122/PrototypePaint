using UnityEngine;
namespace EventBus
{
    public class Injector : MonoBehaviour
    {
        [SerializeField] private MagicRockParent _rockService;
        private PaintManager _paintManager;
        [SerializeField] private EnemyDetecting _enemyDetecting;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Effects _effects;
        [SerializeField] private CanvasDialog _canvas;

        private void Awake()
        {
            _paintManager = new(_rockService, _canvas);
            _enemyDetecting.Inject(_enemySpawner);
            _effects.Inject(_enemyDetecting);
        }

    }
}
