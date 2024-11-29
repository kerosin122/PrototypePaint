using MagicalRocksAndStones;
using Unity.VisualScripting;
using UnityEngine;

public class MagicalRock : MonoBehaviour, IInteractive
{
    private MagicRockParent _manager;
    private AddColorEffect _effect;
    private bool _painted;

    private void Start()
    {
        _effect = GetComponentInChildren<AddColorEffect>(true);
        _manager = GetComponentInParent<MagicRockParent>();
    }
    public void Activated()
    {
        _painted = true;
        _effect.gameObject.SetActive(true);
        EventBus.Instance.PaintActivate?.Invoke(false);
    }

    public void Activate()
    {
        if (!_painted)
        {
            EventBus.Instance.PaintActivate?.Invoke(true);
            _manager.SetCurrentRock(this);
        }
    }

    public void Deactivate()
    {
        EventBus.Instance.PaintActivate?.Invoke(false);
        _manager.SetCurrentRock(null);
    }
}
