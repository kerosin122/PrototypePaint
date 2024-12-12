using UnityEngine;

[RequireComponent(typeof(PlayerCharacteristics))]
public class PlayerMover : MonoBehaviour
{
    private PlayerCharacteristics _player;
    private InputKeyBoard _input = new();
    private Rigidbody2D _rigidbody;
    public bool Movement { get; set; } = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input.CreateInputSystem();
        _player = GetComponent<PlayerCharacteristics>();
    }

    private void Update()
    {
        if (Movement)
        {
            Move();
        }
    }

    private void Move()
    {
        _rigidbody.AddForce(_player.GetSpeed() * Time.deltaTime * (Vector3)_input.GetVector());
    }

    private void OnEnable()
    {
        _input.OnEnable();
    }

    private void OnDisable()
    {
        _input.OnDisable();
    }
    public Vector2 GetMoveInput()
    {
        return _input.GetVector();
    }

}
