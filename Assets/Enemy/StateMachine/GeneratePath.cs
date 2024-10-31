using UnityEngine;
using UnityEngine.AI;

public class GeneratePath
{
    private NavMeshAgent _agent;
    private GameObject[] _positions;
    private System.Random _random;

    public GeneratePath(GameObject[] positions, NavMeshAgent agent)
    {
        _positions = positions;
        _agent = agent;
        _random = new System.Random(1565);
    }

    public void SetPathEnemy()
    {
        SetPositionToMove(ChangePosition());
    }

    private Vector3 ChangePosition()
    {
        return _positions[_random.Next(0, _positions.Length - 1)].transform.position;
    }

    private void SetPositionToMove(Vector3 targetPos)
    {
        _agent.SetDestination(targetPos);
    }
}
