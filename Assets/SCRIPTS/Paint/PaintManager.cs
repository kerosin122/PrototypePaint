using UnityEngine;
namespace EventBus
{
    public class PaintManager
    {
        private IMagicRockService _magicRockService;
        private IViewService _view;

        public PaintManager(IMagicRockService MagicRockService, IViewService view)
        {
            _view = view;
            _magicRockService = MagicRockService;
            EventBus.Instance.Subscribe<RuneIsColoredSignals>(CheckPaintedRocks, 0);
        }

        public void CheckPaintedRocks(RuneIsColoredSignals signals)
        {
            if (_magicRockService.GetCountRockPainted() >= _magicRockService.GetCountRockAll())
            {
                DialogManager.ShowDialog<WinPanel>(_view);
            }
        }
    }
}
