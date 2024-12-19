using UnityEngine;

public class AttackTransition : Transition
{
    private void Update()
    {
        if (CheckDistance() <= Agent.stoppingDistance)
        {
            EnableNextTransition();
            return;
        }
        EnableBackTransition();
    }
    private float CheckDistance()
    {
        return Vector3.Distance(transform.position, Target.transform.position);
    }

    private void EnableNextTransition()
    {
        NeedNextTransit = true;
    }

    private void EnableBackTransition()
    {
        NeedBackTransit = true;
    }

    private void OnDisable()
    {
        NeedBackTransit = false;
        NeedNextTransit = false;
    }
}
