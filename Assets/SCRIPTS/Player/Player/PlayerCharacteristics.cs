using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _maxHealth;
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
    }


    public float GetSpeed()
    {
        return _speed;
    }

    public void SetSpeed(float value)
    {
        _speed *= value;
    }
}
