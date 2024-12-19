using UnityEngine;
namespace EventBus
{
    public class Injector : MonoBehaviour
    {
        [SerializeField] private MagicRockParent _rockService;
        [SerializeField] private EnemyDetecting _enemyDetecting;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Effects _effects;
        [SerializeField] private CanvasDialog _canvas;
        [SerializeField] private PlayerMover _player;
        [SerializeField] private CustomPointEffector _effector;
        private PaintManager _paintManager;
        private GameController _gameController;

        private void Awake()
        {
            _effector.Inject(_enemyDetecting);
            _gameController = new(_player);
            _gameController.OnEnable();
            _paintManager = new(_rockService, _canvas);
            _enemyDetecting.Inject(_enemySpawner);
            _effects.Inject(_enemyDetecting);
        }

    }
}
