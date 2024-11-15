using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private SprayPaint _paint;
    private Touch _touch;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            // Ray ray = Camera.main.ScreenPointToRay(_touch.position);
            // if (Physics.Raycast(ray, out RaycastHit hit))
            // {
            _paint.Draw(_touch.position);
            // }
        }
    }
}
