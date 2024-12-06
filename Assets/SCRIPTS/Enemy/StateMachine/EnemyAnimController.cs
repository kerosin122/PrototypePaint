using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimController : MonoBehaviour
{
    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        CheckTargetPos();
    }
    private void CheckTargetPos()
    {
        if (agent.pathEndPosition.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

    }

}
