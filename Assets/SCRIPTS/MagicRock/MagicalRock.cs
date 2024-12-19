using MagicalRocksAndStones;
using UnityEngine;
namespace EventBus
{

    public class MagicalRock : MonoBehaviour, IInteractive
    {
        private MagicRockParent _manager;
        private CustomPointEffector _effector;
        private AddColorEffect _effect;
        private bool _painted;

        private void Start()
        {
            _effect = GetComponentInChildren<AddColorEffect>(true);
            _manager = GetComponentInParent<MagicRockParent>();
            _effector = GetComponentInParent<CustomPointEffector>();
        }
        public void RockIsActivated()
        {
            _painted = true;
            _effector.EnableEffector(transform.position);
            _effect.gameObject.SetActive(true);
            EventBus.Instance.Invoke(new DrawingModeAvailableSignals(false));
        }

        public void Activate()
        {
            if (!_painted)
            {
                EventBus.Instance.Invoke(new DrawingModeAvailableSignals(true));
                _manager.SetCurrentRock(this);
            }
        }

        public void Deactivate()
        {
            EventBus.Instance.Invoke(new DrawingModeAvailableSignals(false));
            _manager.SetCurrentRock(null);
        }
    }
}
