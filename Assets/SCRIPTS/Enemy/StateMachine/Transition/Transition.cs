using UnityEngine;
using UnityEngine.AI;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetBackState;
    [SerializeField] private State _targetNextState;
    public State TargetNextState => _targetNextState;
    public State TargetBackState => _targetBackState;
    public bool NeedNextTransit { get; protected set; }
    public bool NeedBackTransit { get; protected set; }
    protected PlayerMover Target { get; private set; }
    protected NavMeshAgent Agent;
    protected TimeCounting Timer = new();
    private SpriteRenderer spriteRenderer;
    public void Initialize(PlayerMover target, NavMeshAgent agent)
    {
        Target = target;
        Agent = agent;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
       if (Agent.steeringTarget.x > transform.position.x)
    {
        spriteRenderer.flipX = true;
    }
    else if (Agent.steeringTarget.x < transform.position.x)
    {
        spriteRenderer.flipX = false;
    }
    }

}
