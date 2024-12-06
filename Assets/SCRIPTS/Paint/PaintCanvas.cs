using UnityEngine;
namespace EventBus
{

  public class PaintCanvas : MonoBehaviour
  {
    private void SwitchVisible(RuneIsColoredSignals signals)
    {
      gameObject.SetActive(false);
    }
    private void OnEnable()
    {
      EventBus.Instance.Subscribe<RuneIsColoredSignals>(SwitchVisible, 0);
    }
    private void OnDisable()
    {
      EventBus.Instance.Unsubscribe<RuneIsColoredSignals>(SwitchVisible);
    }
  }
}
