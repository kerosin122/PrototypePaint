using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    private Player _player;
    private SpriteRenderer _playerSpriteRenderer;
    private SpriteRenderer _thisSpriteRenderer;


    private void FixedUpdate()
    {
        CheckLayers();
    }
    private void CheckLayers()
    {
        if (_player.transform.position.y >= transform.position.y)
        {
            _thisSpriteRenderer.sortingOrder = _playerSpriteRenderer.sortingOrder + 1;
        }
        else
        {
            _thisSpriteRenderer.sortingOrder = _playerSpriteRenderer.sortingOrder - 1;
        }
    }
}
