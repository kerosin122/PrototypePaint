using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintNew : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    private Texture2D _texture;
    private Touch _touch;

    private void Start()
    {
        _texture = new(128, 128);
        // _sprite.sprite = _texture;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            Vector2 pixel = new(Mathf.Round(_touch.position.x), Mathf.Round(_touch.position.y));
            Debug.Log(pixel);
        }
    }
}
