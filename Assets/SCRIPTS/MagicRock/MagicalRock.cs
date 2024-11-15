using MagicalRocksAndStones;
using UnityEngine;

public class MagicalRock : MonoBehaviour
{
    private AddColorEffect _effect;

    private void Start()
    {
        _effect = GetComponentInChildren<AddColorEffect>(true);
    }
    public void Activated()
    {
        _effect.gameObject.SetActive(true);
    }
}
