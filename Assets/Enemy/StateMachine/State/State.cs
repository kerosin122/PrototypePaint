using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public abstract class State : MonoBehaviour
{
    protected Animator Animator { get; private set; }
    protected NavMeshAgent Agent { get; private set; }
    protected PlayerMover Target { get; private set; }
    [SerializeField] private Transition[] _transitionsBack;
    [SerializeField] private Transition[] _transitionsNext;

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
            EnumerationTransition(_transitionsBack, true);
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            EnumerationTransition(_transitionsNext, false);
            EnumerationTransition(_transitionsBack, false);
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

    public State GetBackState()
    {
        foreach (var transition in _transitionsBack)
        {
            if (transition.NeedBackTransit)
            {
                return transition.TargetBackState;
            }
        }
        return null;
    }

    private void EnumerationTransition(Transition[] transitions, bool enable)
    {
        foreach (var transition in transitions)
        {
            transition.Initialize(Target, Agent);
            if (transition.enabled != enable)
            {
                transition.enabled = enable;
            }
        }
    }

}
