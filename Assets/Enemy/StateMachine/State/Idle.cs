using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    private void OnEnable()
    {
        // Debug.Log("Cтоим");
        Agent.isStopped = true;
        Animator.SetBool("Idle",true);
    }

    private void OnDisable()
    {
        Agent.isStopped = false;
        Animator.SetBool("Idle",false);
    }
}
