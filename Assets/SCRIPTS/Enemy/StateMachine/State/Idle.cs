using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    private void OnEnable()
    {
        Agent.isStopped = true;
        Animator.SetBool(AnimHash.IdleHash,true);
    }

    private void OnDisable()
    {
        Agent.isStopped = false;
        Animator.SetBool(AnimHash.IdleHash,false);
    }
}
