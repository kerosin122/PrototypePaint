using UnityEngine;
namespace EventBus
{
    public class PaintButton : MonoBehaviour
    {
        private void Awake()
        {
            EventBus.Instance.Subscribe<PaintActivateSignals>(VisibilitySwitch, 0);
            VisibilitySwitch(new PaintActivateSignals(false));
        }

        private void VisibilitySwitch(PaintActivateSignals signals)
        {
            gameObject.SetActive(signals.Activate);
        }

        private void OnDestroy()
        {
            EventBus.Instance.Unsubscribe<PaintActivateSignals>(VisibilitySwitch);
        }
    }
}

