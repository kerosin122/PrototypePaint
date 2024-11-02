using UnityEngine;

public class RunTransition : Transition
{
    [SerializeField] private float _timerSearch;
    [SerializeField] private float _rayDistance = 5;
    [SerializeField] private GameObject _startPointRayCast;

    private void SearchPlayer(bool value)
    {
        if (!value)
        {
            if (RayCastForEnemy.Ray(_startPointRayCast.transform.position, Target.transform.position, _rayDistance))
            {
                NeedNextTransit = true;
            }
            return;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Timer.TimerCounting(_timerSearch));
        Timer.TimeIsUp += SearchPlayer;
    }

    private void OnDisable()
    {
        NeedNextTransit = false;
        StopAllCoroutines();
        Timer.TimeIsUp -= SearchPlayer;
    }
}
