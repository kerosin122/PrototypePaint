using System;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<IInteractive>(out IInteractive interactive))
        {
            interactive.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<IInteractive>(out IInteractive interactive))
        {
            interactive.Deactivate();
        }
    }
}
