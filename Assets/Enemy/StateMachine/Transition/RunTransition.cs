using UnityEngine;

public class RunTransition : Transition
{
    [SerializeField] private float _distanceToTarget;

    private float CheckDistance()
    {
        return Vector3.Distance(transform.position, Target.transform.position);
    }

    private void Update()
    {
        if (_distanceToTarget <= CheckDistance())
        {
            Run();
            return;
        }
        Walking();
    }

    private void Run()
    {
        if (!NeedNextTransit)
        {
            NeedNextTransit = true;
            NeedBackTransit = false;
        }
    }

    private void Walking()
    {
        if (!NeedBackTransit)
        {
            NeedBackTransit = true;
            NeedNextTransit = false;
        }
    }


    private void OnDisable()
    {
        NeedBackTransit = false;
        NeedNextTransit = false;
    }
}
