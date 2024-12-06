using UnityEngine;
namespace EventBus
{

   public class MainCanvas : MonoBehaviour
   {

      private void Awake()
      {
         EventBus.Instance.Subscribe<RuneIsColoredSignals>(SwitchVisible, 0);
      }
      private void OnEnable()
      {
         EventBus.Instance.Unsubscribe<RuneIsColoredSignals>(SwitchVisible);
      }

      private void SwitchVisible(RuneIsColoredSignals signals)
      {
         gameObject.SetActive(true);
      }

      private void OnDisable()
      {
         EventBus.Instance.Subscribe<RuneIsColoredSignals>(SwitchVisible, 0);
      }

   }
}
