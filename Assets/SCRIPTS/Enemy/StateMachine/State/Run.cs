using UnityEngine;

public class Run : State
{
    private float _startSpeedAgent;

    private void Update()
    {
        Agent.SetDestination(Target.transform.position);
    }
    private void OnEnable()
    {
        _startSpeedAgent = Agent.speed;
        Agent.speed *= 1.2f;
        Animator.SetBool(AnimHash.RunHash,true);
    }
    private void OnDisable()
    {
        Agent.speed = _startSpeedAgent;
        Animator.SetBool(AnimHash.RunHash,false);
    }
}
