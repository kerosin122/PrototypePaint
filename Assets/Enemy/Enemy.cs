using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

}
