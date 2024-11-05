using UnityEngine;

public class RunTransition : Transition
{
    [SerializeField] private float _timerSearch;
    [SerializeField] private float _rayDistance = 5;

    private void SearchPlayer(bool value)
    {
        if (!value)
        {
            if (RayCastForEnemy.Ray(transform.position, Target.transform.position, _rayDistance))
            {
                StopAllCoroutines();
                NeedNextTransit = true;
                NeedBackTransit = false;
                return;
            }
            return;
        }
        else
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
