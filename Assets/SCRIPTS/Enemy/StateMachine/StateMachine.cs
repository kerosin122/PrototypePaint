using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private PlayerMover _target;
    private State _currentState;

    private void Start()
    {
        Restart(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        State nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }

        State backState = _currentState.GetBackState();
        if (backState != null)
        {
            Transit(backState);
        }
    }

    private void Restart(State startState)
    {
        _currentState = startState;
        _currentState?.Enter(_target);
    }

    private void Transit(State state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter(_target);
    }


}



