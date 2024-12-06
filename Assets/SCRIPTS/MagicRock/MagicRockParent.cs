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
        private void RockIsPainted(RuneIsColoredSignals signal)
        {
            _rockIsPainted.Add(_currentRock);
            _counterText.text = $"{_rockIsPainted.Count}/{_rockAll.Length}";/// унести от сюда потом, пока лень и неохото
            _currentRock.RockIsActivated();
        }
        public void SetCurrentRock(MagicalRock rock)
        {
            _currentRock = rock;
        }
        public int GetCountRockAll()
        {
            return _rockAll.Length;
        }
        public int GetCountRockPainted()
        {
            return _rockIsPainted.Count;
        }
        private void OnEnable()
        {
            EventBus.Instance.Subscribe<RuneIsColoredSignals>(RockIsPainted, 1);
        }
        private void OnDisable()
        {
            EventBus.Instance.Unsubscribe<RuneIsColoredSignals>(RockIsPainted);
        }
    }
}
