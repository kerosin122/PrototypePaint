
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health;
    private int _maxHealth;
    private PlayerCharacteristics _characteristics;
    private void Awake()
    {
        _characteristics = GetComponent<PlayerCharacteristics>();
        _maxHealth = _characteristics.MaxHealth;
        _health = _maxHealth;
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log("Ай, больно!!");
        if (_health <= 0)
        {
            Debug.Log("Помер!");
        }
    }
}
