using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    private void OnEnable()
    {
        Agent.isStopped = true;
    }

    private void OnDisable()
    {
        Agent.isStopped = false;
    }
}
