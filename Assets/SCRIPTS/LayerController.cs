using UnityEngine;

public class LayerController : MonoBehaviour
{
    private SpriteRenderer _playerSprite;
    private void Awake()
    {
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Props>(out Props props))
        {
            if (props.TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite))
            {
                if (transform.position.y >= collider.transform.position.y)
                {
                    sprite.sortingOrder = _playerSprite.sortingOrder + 1;
                }
                else
                {
                    sprite.sortingOrder = _playerSprite.sortingOrder - 1;
                }
            }
        }
    }
}
