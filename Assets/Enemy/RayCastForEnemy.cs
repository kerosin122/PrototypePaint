using UnityEngine;


public static class RayCastForEnemy
{
    public static bool Ray(Vector3 currentPosition, Vector3 targetPosition, float distance)
    {
        Ray ray = new(currentPosition, targetPosition);
        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            if (hit.collider.TryGetComponent<PlayerMover>(out PlayerMover player))
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
