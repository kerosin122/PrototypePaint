using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float GetSpeed()
    {
        return _speed;
    }

    public void SetSpeed(float value)
    {
        _speed *= value;
    }
}
