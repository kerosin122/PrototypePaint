using UnityEngine;

public class WalkingTransition : Transition
{
    [SerializeField] private float _duration;

    private void Update()
    {
        EnableBackState();
    }

    private void EnableBackState()
    {
        if (TargetNextState.enabled && !TargetBackState.enabled && !Agent.hasPath)
        {
            NeedBackTransit = true;
        }
    }

    private void EnableNextState(bool value)
    {
        NeedNextTransit = value;
    }

    private void OnEnable()
    {
        if (TargetBackState.enabled && !TargetNextState.enabled)
        {
            Timer.TimeIsUp += EnableNextState;
            StartCoroutine(Timer.TimerCounting(_duration));
        }
    }

    private void OnDisable()
    {
        NeedNextTransit = false;
        NeedBackTransit = false;
        StopAllCoroutines();
        Timer.TimeIsUp -= EnableNextState;
    }

}
