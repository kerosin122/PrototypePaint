using UnityEngine;

public class PaintButton : MonoBehaviour
{
    private void Awake()
    {
        EventBus.Instance.PaintActivate += VisibilitySwitch;
        VisibilitySwitch(false);
    }

    private void VisibilitySwitch(bool value)
    {
        gameObject.SetActive(value);
    }

    private void OnDestroy()
    {
        EventBus.Instance.PaintActivate -= VisibilitySwitch;
    }
}

