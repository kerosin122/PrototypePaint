using UnityEngine;

public static class RayCastForEnemy
{
    public static bool Ray(Vector2 currentPosition, Vector2 targetPosition,float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(currentPosition, targetPosition - currentPosition, distance);
        if (hit.collider.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
           return true;
        }
        return false;
    }
}
