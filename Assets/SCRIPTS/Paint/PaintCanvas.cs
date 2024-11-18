using UnityEngine;

public class PaintCanvas : MonoBehaviour
{
  private SystemGrafity _systemGrafity;
  //  private Canvas _canvas;

  private void OnEnable()
  {
    //     if(!_canvas){
    //   _canvas = GetComponent<Canvas>();
    //     }
    if (!_systemGrafity)
    {
      _systemGrafity = GetComponentInChildren<SystemGrafity>();
    }
    _systemGrafity.FinishedGraffiti += SwitchVisible;
  }
  private void SwitchVisible()
  {
    gameObject.SetActive(false);
  }
  private void OnDisable()
  {
    _systemGrafity.FinishedGraffiti -= SwitchVisible;
  }
}
