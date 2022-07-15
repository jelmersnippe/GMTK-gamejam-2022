using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Projectile projectile;

    public void Fire()
    {
        Instantiate(projectile, firePoint.position, transform.rotation);
    }
}
