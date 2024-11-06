using UnityEngine;
using UnityEngine.AI;

public class GeneratePath
{
    private NavMeshAgent _agent;
    private GameObject[] _positions;
    private Vector3 _currentPos;


    public GeneratePath(GameObject[] positions, NavMeshAgent agent)
    {
        _positions = positions;
        _agent = agent;
    }

    public void SetPathEnemy()
    {
        SetPositionToMove(ChangePosition());
    }

    private Vector3 ChangePosition()
    {
        Vector3 newPos = _positions[Random.Range(0, _positions.Length)].transform.position;
        while (newPos == _currentPos)
        {
            newPos = _positions[Random.Range(0, _positions.Length)].transform.position;
        }
        _currentPos = newPos;
        return newPos;
    }

    private void SetPositionToMove(Vector3 targetPos)
    {
        _agent.SetDestination(targetPos);
    }
}
