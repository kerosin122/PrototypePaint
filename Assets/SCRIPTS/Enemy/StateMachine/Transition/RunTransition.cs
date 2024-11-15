using UnityEngine;

public class RunTransition : Transition
{
    [SerializeField] private float _timerSearch;
    [SerializeField] private float _rayDistance = 5;

    private void SearchPlayer(bool value)
    {
        if (RayCastForEnemy.Ray(transform.position, Target.transform.position, _rayDistance))
        {
            NeedNextTransit = true;
            NeedBackTransit = false;
        }

        if (value)
        {
            NeedNextTransit = false;
            NeedBackTransit = true;
        }
    }

    private void OnEnable()
    {
        Timer.TimeIsUp += SearchPlayer;
        StartCoroutine(Timer.TimerCounting(_timerSearch));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        Timer.TimeIsUp -= SearchPlayer;
    }
}
