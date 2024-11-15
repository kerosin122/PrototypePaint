using UnityEngine;

public class PaintButton : MonoBehaviour
{
    [SerializeField] private PlayerTrigger _player;
    [SerializeField] private Canvas _paintScene;

    private void Awake()
    {
        _player.Trigger += ChangeVisible;
        ChangeVisible(false);
    }

    private void ChangeVisible(bool value)
    {
        gameObject.SetActive(value);
    }

    private void OnDestroy()
    {
        _player.Trigger -= ChangeVisible;
    }
}

