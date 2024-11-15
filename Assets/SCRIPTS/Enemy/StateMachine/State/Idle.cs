using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    private void OnEnable()
    {
        // Debug.Log("Cтоим");
        Agent.isStopped = true;
    }

    private void OnDisable()
    {
        Agent.isStopped = false;
    }
}
