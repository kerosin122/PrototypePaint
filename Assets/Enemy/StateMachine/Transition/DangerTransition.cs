using UnityEngine;

public class DangerTransition : Transition
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!NeedNextTransit && collider.GetComponent<PlayerMover>())
        {
            NeedNextTransit = true;
            NeedBackTransit = false;
        }
    }

    private void Walking(bool value)
    {
        if (value)
        {
            NeedBackTransit = true;
            NeedNextTransit = false;
        }
    }

    private void OnEnable()
    {
        if (NeedNextTransit)
        {
            StartCoroutine(Timer.TimerCounting(3f));
        }
        Timer.TimeIsUp += Walking;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        Timer.TimeIsUp -= Walking;
    }
}
