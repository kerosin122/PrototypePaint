using UnityEngine;
namespace EventBus
{
    public class PaintManager
    {
        private IMagicRockService _magicRockService;

        public PaintManager(IMagicRockService MagicRockService)
        {
            _magicRockService = MagicRockService;
            EventBus.Instance.Subscribe<CheckingPaintedGrafitySignals>(CheckPaintedRocks, 0);
        }

        public void CheckPaintedRocks(CheckingPaintedGrafitySignals signals)
        {
            if (_magicRockService.GetCountRockPainted() >= _magicRockService.GetCountRockAll())
            {
                Debug.Log("Уровень пройден");
            }
        }
    }
}
