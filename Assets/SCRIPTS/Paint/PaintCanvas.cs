using UnityEngine;

public class PaintCanvas : MonoBehaviour
{
  private void SwitchVisible()
  {
    gameObject.SetActive(false);
  }
  private void OnEnable()
  {
    EventBus.Instance.FinishedGraffiti += SwitchVisible;
  }
  private void OnDisable()
  {
    EventBus.Instance.FinishedGraffiti -= SwitchVisible;
  }
}
