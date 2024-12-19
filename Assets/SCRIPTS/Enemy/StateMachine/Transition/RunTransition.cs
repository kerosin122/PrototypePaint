using UnityEngine;

public class RunTransition : Transition
{
    [SerializeField] private float _timerSearch;
    [SerializeField] private float _rayDistance = 5;

    private void EnableNextState()
    {
        if (RayCastForEnemy.Ray(transform.position, Target.transform.position, _rayDistance))
        {
            NeedNextTransit = true;
        }
    }
    private void EnableBackState(bool value)
    {
        NeedBackTransit = value;
    }
    private void FixedUpdate()
    {
        EnableNextState();
    }

    private void OnEnable()
    {
        if (TargetNextState.enabled && !TargetBackState.enabled)
        {
            Timer.TimeIsUp += EnableBackState;
            StartCoroutine(Timer.TimerCounting(_timerSearch));
        }
    }

    private void OnDisable()
    {
        NeedNextTransit = false;
        NeedBackTransit = false;
        StopAllCoroutines();
        Timer.TimeIsUp -= EnableBackState;
    }
}
