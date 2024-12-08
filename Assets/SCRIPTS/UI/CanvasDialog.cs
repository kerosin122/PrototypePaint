using UnityEngine;

public class CanvasDialog : MonoBehaviour, IViewService
{
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }
    public Canvas GetCurrentCanvas()
    {
        return _canvas;
    }
}
