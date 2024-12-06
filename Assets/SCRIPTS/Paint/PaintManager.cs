using UnityEngine;
namespace EventBus
{
    public class PaintManager
    {
        private IMagicRockService _magicRockService;

        public PaintManager(IMagicRockService MagicRockService)
        {
            _magicRockService = MagicRockService;
            EventBus.Instance.Subscribe<RuneIsColoredSignals>(CheckPaintedRocks, 0);
        }

        public void CheckPaintedRocks(RuneIsColoredSignals signals)
        {
            if (_magicRockService.GetCountRockPainted() >= _magicRockService.GetCountRockAll())
            {
                Debug.Log("Уровень пройден");
            }
        }
    }
}
