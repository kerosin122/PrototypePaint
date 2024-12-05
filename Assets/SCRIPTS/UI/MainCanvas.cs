using UnityEngine;
namespace EventBus
{

   public class MainCanvas : MonoBehaviour
   {
      private void OnEnable()
      {
         // EventBus.Instance.FinishedGraffiti -= SwitchVisible;
         EventBus.Instance.Unsubscribe<FinishedGraffitiSignals>(SwitchVisible);
      }

      private void SwitchVisible(FinishedGraffitiSignals signals)
      {
         gameObject.SetActive(true);
      }

      private void OnDisable()
      {
         EventBus.Instance.Subscribe<FinishedGraffitiSignals>(SwitchVisible, 0);
         // EventBus.Instance.FinishedGraffiti += SwitchVisible;
      }

   }
}
