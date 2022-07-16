using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Projectile projectile;

    [Header("Weapon Stats")]
    [Min(0.1f)]
    public float fireRate = 1f;
    public int damage = 10;
    public int shots = 1;
    public float spread = 5f;

    private float timeUntillNextShot;

    private void Update()
    {
        if (timeUntillNextShot > 0f)
        {
            timeUntillNextShot -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        if (timeUntillNextShot > 0f)
        {
            return;
        }

        for (int i = 0; i < shots; i++)
        {
            Projectile spawnedProjectile = Instantiate(projectile, firePoint.position, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, Random.Range(-spread, spread))));
            spawnedProjectile.damage = damage;
        }

        timeUntillNextShot = 1f / fireRate;
    }
}
