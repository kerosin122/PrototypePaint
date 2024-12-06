using UnityEngine;
namespace EventBus
{
    public class PaintButton : MonoBehaviour
    {
        private void Awake()
        {
            EventBus.Instance.Subscribe<DrawingModeAvailableSignals>(VisibilitySwitch, 0);
            VisibilitySwitch(new DrawingModeAvailableSignals(false));
        }

        private void VisibilitySwitch(DrawingModeAvailableSignals signals)
        {
            gameObject.SetActive(signals.Activate);
        }

        private void OnDestroy()
        {
            EventBus.Instance.Unsubscribe<DrawingModeAvailableSignals>(VisibilitySwitch);
        }
    }
}

