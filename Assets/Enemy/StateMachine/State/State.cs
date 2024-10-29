using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public abstract class State : MonoBehaviour
{
    protected Animator Animator { get; private set; }
    protected NavMeshAgent Agent { get; private set; }
    protected PlayerMover Target { get; private set; }
    [SerializeField] private Transition[] _transitionsNext;
    // [SerializeField] private Transition[] _transitionsBack;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    public void Enter(PlayerMover target)
    {
        if (!enabled)
        {
            Target = target;
            enabled = true;
            EnumerationTransition(_transitionsNext, true);
            // EnumerationTransition(_transitionsBack, true);
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            EnumerationTransition(_transitionsNext, false);
            // EnumerationTransition(_transitionsBack, false);
            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitionsNext)
        {
            if (transition.NeedNextTransit)
            {
                return transition.TargetNextState;
            }
        }
        return null;
    }

    // public State GetBackState()
    // {
    //     foreach (var transition in _transitionsBack)
    //     {
    //         if (transition.NeedBackTransit)
    //         {
    //             return transition.TargetNextState;
    //         }
    //     }
    //     return null;
    // }

    private void EnumerationTransition(Transition[] transitions, bool value)
    {
        foreach (var transition in transitions)
        {
            if (!transition.enabled)
            {
                transition.enabled = value;
                transition.Initialize(Target, Agent);
            }
        }
    }

}