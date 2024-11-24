using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MagicRockParent : MonoBehaviour, IMagicRockService
{
    [SerializeField] TextMeshProUGUI _counterText;
    private MagicalRock _currentRock;
    private MagicalRock[] _rockAll;
    private List<MagicalRock> _rockIsPainted = new();

    private void Awake()
    {
        _rockAll = GetComponentsInChildren<MagicalRock>();
    }

    private void RockIsPainted()
    {
        _rockIsPainted.Add(_currentRock);
        _counterText.text = $"{_rockIsPainted.Count}/{_rockAll.Length}";
        _currentRock.Activated();
        EventBus.Instance.CheckingPaintedGrafity?.Invoke();
    }

    public void SetCurrentRock(MagicalRock rock)
    {
        _currentRock = rock;
    }

    private void OnEnable()
    {
        EventBus.Instance.FinishedGraffiti += RockIsPainted;
    }
    private void OnDisable()
    {
        EventBus.Instance.FinishedGraffiti -= RockIsPainted;
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
