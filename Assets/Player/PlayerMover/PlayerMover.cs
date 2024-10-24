using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private PlayerCharacteristics _player;
    private InputKeyBoard _input = new();


    private void Awake()
    {
        _input.CreateInputSystem();
        _player = GetComponent<PlayerCharacteristics>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += _player.GetSpeed() * Time.deltaTime * (Vector3)_input.GetVector();// пока пускай так
    }


    private void OnEnable()
    {
        _input.OnEnable();
    }

    private void OnDisable()
    {
        _input.OnDisable();
    }

}
