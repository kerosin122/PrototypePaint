using UnityEngine;

public class AttackTransition : Transition
{
    [SerializeField] private float _distanceToTarget;


    private void Update()
    {
        if (CheckDistance() <= _distanceToTarget)
        {
            Run();
            return;
        }
        Danger();
    }
    private float CheckDistance()
    {
        return Vector3.Distance(transform.position, Target.transform.position);
    }

    private void Run()
    {
        if (!NeedNextTransit)
        {
            NeedNextTransit = true;
            NeedBackTransit = false;
        }
    }

    private void Danger()
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
