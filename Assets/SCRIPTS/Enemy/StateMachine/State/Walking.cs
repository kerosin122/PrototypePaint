using UnityEngine;

public class Walking : State
{
    [SerializeField] private GameObject[] _checkPoint;
    private GeneratePath _path;

    private void OnEnable()
    {
        _path ??= new(_checkPoint, Agent);
        _path.SetPathEnemy();
    }


}
