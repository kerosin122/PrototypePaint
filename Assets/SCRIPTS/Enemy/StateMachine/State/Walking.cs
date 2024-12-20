using UnityEngine;

public class Walking : State
{
    private float _startSpeedAgent;
    [SerializeField] private GameObject[] _checkPoint;
    private GeneratePath _path;

    private void OnEnable()
    {
        _startSpeedAgent = Agent.speed;
        _path ??= new(_checkPoint, Agent);
        _path.SetPathEnemy();
        Agent.speed *= 0.6f;
        Animator.SetBool(AnimHash.WalkingHash,true);
    }
    void OnDisable()
    {
        Agent.speed = _startSpeedAgent;
        Animator.SetBool(AnimHash.WalkingHash,false);
    }


}
