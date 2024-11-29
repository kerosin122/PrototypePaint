using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : State
{
    private void OnEnable()
    {
        Agent.isStopped = true;
        Animator.SetBool("Danger",true);
    }
    private void OnDisable()
    {
        Agent.isStopped = false;
        Animator.SetBool("Danger",false);
    }
}
