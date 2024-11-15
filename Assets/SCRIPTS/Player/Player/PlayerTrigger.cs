using System;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public Action<bool> Trigger;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<MagicalRock>(out MagicalRock magicalRock))
        {
            Trigger?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<MagicalRock>(out MagicalRock magicalRock))
        {
            Trigger?.Invoke(false);
        }
    }
}
