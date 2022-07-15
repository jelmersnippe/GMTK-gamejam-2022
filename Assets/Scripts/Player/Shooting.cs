using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Projectile projectile;
    public Transform firePoint;

    public void Shoot(Vector2 targetPosition)
    {
        Instantiate(projectile, firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, MousePosition.GetAngleToMouse(firePoint.position))));
    }
}
