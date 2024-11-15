using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : State
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
