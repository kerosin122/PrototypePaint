using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : State
{
    [SerializeField] private CircleCollider2D _collider;

    
    private void OnEnable()
    {
        Agent.isStopped = true;
        _collider.enabled = false;
    }
    private void OnDisable()
    {
        _collider.enabled = true;
        Agent.isStopped = false;
    }
}
