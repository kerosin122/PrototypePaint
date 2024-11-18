using UnityEngine;

public class MainCanvas : MonoBehaviour
{
   [SerializeField] private SystemGrafity _grafity;
 

    private void OnEnable() {
        _grafity.FinishedGraffiti+=SwitchVisible;
    }

    private void SwitchVisible(){
   gameObject.SetActive(true);
 }

 private void OnDisable() {
    // _grafity.FinishedGraffiti=SwitchVisible;
 }

}
