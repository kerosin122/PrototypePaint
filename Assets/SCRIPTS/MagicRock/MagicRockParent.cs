using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace EventBus
{
    public class MagicRockParent : MonoBehaviour, IMagicRockService
    {
        [SerializeField] private TextMeshProUGUI _counterText;
        private MagicalRock _currentRock;
        private MagicalRock[] _rockAll;
        private List<MagicalRock> _rockIsPainted = new();

        private void Awake()
        {
            _rockAll = GetComponentsInChildren<MagicalRock>();
        }

        private void RockIsPainted(FinishedGraffitiSignals signal)
        {
            _rockIsPainted.Add(_currentRock);
            _counterText.text = $"{_rockIsPainted.Count}/{_rockAll.Length}";
            _currentRock.Activated();
            EventBus.Instance.Invoke(new CheckingPaintedGrafitySignals());
        }

        public void SetCurrentRock(MagicalRock rock)
        {
            _currentRock = rock;
        }
        private void OnEnable()
        {
            EventBus.Instance.Subscribe<FinishedGraffitiSignals>(RockIsPainted, 0);
        }
        private void OnDisable()
        {
            EventBus.Instance.Unsubscribe<FinishedGraffitiSignals>(RockIsPainted);
        }

        public int GetCountRockAll()
        {
            return _rockAll.Length;
        }
        public int GetCountRockPainted()
        {
            return _rockIsPainted.Count;
        }
    }
}
