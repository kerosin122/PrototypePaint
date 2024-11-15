using UnityEngine;

public class PaintButton : MonoBehaviour
{
    [SerializeField] private PlayerTrigger _player;

    private void Awake()
    {
        _player.Trigger += VisibilitySwitch;
        VisibilitySwitch(false);
    }

    private void VisibilitySwitch(bool value)
    {
        gameObject.SetActive(value);
    }

    private void OnDestroy()
    {
        _player.Trigger -= VisibilitySwitch;
    }
}

