using UnityEngine;

public class MainCanvas : MonoBehaviour
{
   private void OnEnable()
   {
      EventBus.Instance.FinishedGraffiti -= SwitchVisible;
   }

   private void SwitchVisible()
   {
      gameObject.SetActive(true);
   }

   private void OnDisable()
   {
      EventBus.Instance.FinishedGraffiti += SwitchVisible;
   }

}
