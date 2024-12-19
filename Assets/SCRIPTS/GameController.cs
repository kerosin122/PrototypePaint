using UnityEngine;
namespace EventBus
{
    public class GameController
    {
        private PlayerMover _playerMover;

        public GameController(PlayerMover player)
        {
            _playerMover = player;
        }
        public void StopGame()
        {

        }

        public void StartGame()
        {

        }

        public void RestartGame()
        {

        }

        private void PlayerMoving(PlayerMovingSignals signal)
        {
            _playerMover.Movement = signal.Moving;
        }

        public void OnEnable()
        {
            EventBus.Instance.Subscribe<PlayerMovingSignals>(PlayerMoving, 0);
        }

        private void OnDisable()
        {
            EventBus.Instance.Unsubscribe<PlayerMovingSignals>(PlayerMoving);
        }
    }
}
