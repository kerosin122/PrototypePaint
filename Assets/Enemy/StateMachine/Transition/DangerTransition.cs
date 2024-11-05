using UnityEngine;

public class DangerTransition : Transition
{
    [SerializeField] private float _duration;
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
            StartCoroutine(Timer.TimerCounting(_duration));
        }
        Timer.TimeIsUp += Walking;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        Timer.TimeIsUp -= Walking;
    }
}
