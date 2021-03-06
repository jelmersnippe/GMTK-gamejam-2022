using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Projectile projectile;
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public Sound[] sounds;

    [Header("Weapon Stats")]
    [Min(0.1f)]
    public float fireRate = 1f;
    public int damage = 10;
    public int shots = 1;
    public float spread = 5f;
    public int maxHits = 1;
    public float projectileSpeed = 25f;

    public float cameraShakeMagnitude = 0.2f;

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
        CameraShake.instance.Shake(0.1f, cameraShakeMagnitude);

        if (sounds.Length > 0)
        {
            int soundIndex = Random.Range(0, sounds.Length);
            AudioManager.PlaySound(audioSource, sounds[soundIndex]);
        }

        for (int i = 0; i < shots; i++)
        {
            Projectile spawnedProjectile = Instantiate(projectile, firePoint.position, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, Random.Range(-spread, spread))));
            spawnedProjectile.damage = damage;
            spawnedProjectile.maxHits = maxHits;
            spawnedProjectile.speed = projectileSpeed;
        }

        timeUntillNextShot = 1f / fireRate;
    }
}
