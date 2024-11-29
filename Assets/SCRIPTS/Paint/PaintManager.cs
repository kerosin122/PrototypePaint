using UnityEngine;

public class PaintManager
{
    private IMagicRockService _magicRockService;

    public PaintManager(IMagicRockService MagicRockService)
    {
        _magicRockService = MagicRockService;
        EventBus.Instance.CheckingPaintedGrafity += CheckPaintedRocks;
    }

    public void CheckPaintedRocks()
    {
        if (_magicRockService.GetCountRockPainted() >= _magicRockService.GetCountRockAll())
        {
            Debug.Log("Уровень пройден");
        }
    }


}
