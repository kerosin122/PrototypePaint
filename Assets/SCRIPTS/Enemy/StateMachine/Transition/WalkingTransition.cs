using UnityEngine;

public class WalkingTransition : Transition
{

    [SerializeField] private float _duration;

    private void Update()
    {
        StopWalking();
    }

    private void StopWalking()
    {
        if (NeedNextTransit && !Agent.hasPath)
        {
            NeedNextTransit = false;
            NeedBackTransit = true;
        }
    }

    private void NeedTransition(bool value)
    {
        NeedNextTransit = value;
    }

    private void OnEnable()
    {
        if (!NeedNextTransit)
        {
            NeedBackTransit = false;
            Timer.TimeIsUp += NeedTransition;
            StartCoroutine(Timer.TimerCounting(_duration));
        }
    }

    private void OnDisable()
    {
        if (NeedNextTransit)
        {
            Timer.TimeIsUp -= NeedTransition;
        }
    }

}
