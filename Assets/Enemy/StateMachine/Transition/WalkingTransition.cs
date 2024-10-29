using UnityEngine;

public class WalkingTransition : Transition
{
    private void StartTimer()
    {
        StartCoroutine(TimeCounting.TimerCounting(2f));
    }

    // private void Update()
    // {
    //     if (NeedNextTransit)
    //     {
    //         StopWalking();
    //     }
    // }

    // private void StopWalking()
    // {
    //     if (Agent.hasPath)
    //     {
    //         NeedBackTransit = true;
    //         NeedNextTransit = false;
    //     }
    // }

    private void NeedTransition(bool value)
    {
        NeedNextTransit = value;
        // NeedBackTransit = false;
    }

    private void OnEnable()
    {
        TimeCounting.TimeIsUp += NeedTransition;
        StartTimer();
    }

    private void OnDisable()
    {
        TimeCounting.TimeIsUp -= NeedTransition;
    }

}
