using MagicalRocksAndStones;
using Unity.VisualScripting;
using UnityEngine;
namespace EventBus
{

    public class MagicalRock : MonoBehaviour, IInteractive
    {
        private MagicRockParent _manager;
        private AddColorEffect _effect;
        private bool _painted;

        private void Start()
        {
            _effect = GetComponentInChildren<AddColorEffect>(true);
            _manager = GetComponentInParent<MagicRockParent>();
        }
        public void Activated()
        {
            _painted = true;
            _effect.gameObject.SetActive(true);
            // EventBus.Instance.PaintActivate?.Invoke(false);
            EventBus.Instance.Invoke(new PaintActivateSignals(false));
        }

        public void Activate()
        {
            if (!_painted)
            {
                // EventBus.Instance.PaintActivate?.Invoke(true);
                EventBus.Instance.Invoke(new PaintActivateSignals(true));
                _manager.SetCurrentRock(this);
            }
        }

        public void Deactivate()
        {
            EventBus.Instance.Invoke(new PaintActivateSignals(false));
            // EventBus.Instance.PaintActivate?.Invoke(false);
            _manager.SetCurrentRock(null);
        }
    }
}
