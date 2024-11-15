using UnityEngine;

public class InputKeyBoard
{
    private InputSystem _input;

    public Vector2 GetVector()
    {
        return _input.PlayerMove.Move.ReadValue<Vector2>();
    }

    public void CreateInputSystem()
    {
        _input = new();
    }

    public void OnEnable()
    {
        _input.Enable();
    }

    public void OnDisable()
    {
        _input.Disable();
    }
}
