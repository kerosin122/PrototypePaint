using UnityEngine;
namespace EventBus
{

  public class PaintCanvas : MonoBehaviour
  {
    private void SwitchVisible(FinishedGraffitiSignals signals)
    {
      gameObject.SetActive(false);
    }
    private void OnEnable()
    {
      EventBus.Instance.Subscribe<FinishedGraffitiSignals>(SwitchVisible, 0);
    }
    private void OnDisable()
    {
      EventBus.Instance.Unsubscribe<FinishedGraffitiSignals>(SwitchVisible);
    }
  }
}
