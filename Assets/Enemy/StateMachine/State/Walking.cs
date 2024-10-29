using UnityEngine;

public class Walking : State
{
    private void Update()
    {
        Agent.SetDestination(Target.transform.position);
    }
    private void OnEnable()
    {
        // Debug.Log("Идем!");
    }
}
