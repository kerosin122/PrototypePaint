using UnityEngine;

public class Run : State
{
    private float _startSpeedAgent;

    private void Update()
    {
        Agent.SetDestination(Target.transform.position);
        Debug.Log(Agent.speed);
    }
    private void OnEnable()
    {
        _startSpeedAgent = Agent.speed;
        Agent.speed *= 1.2f;
    }
    private void OnDisable()
    {
        Agent.speed = _startSpeedAgent;
    }
}
