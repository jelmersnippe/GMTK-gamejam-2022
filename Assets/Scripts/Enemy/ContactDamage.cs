using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public int damage;
    public LayerMask targetMask;

    public float cooldown = 0.5f;
    public float remainingCooldown;

    private void Update()
    {
        if (remainingCooldown > 0f)
        {
            remainingCooldown -= Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (remainingCooldown > 0f)
        {
            return;
        }

        int otherInstanceId = other.gameObject.GetInstanceID();
        if (targetMask != (targetMask | (1 << other.gameObject.layer)))
        {
            return;
        }

        Damageable damageable = other.gameObject.GetComponent<Damageable>();
        if (damageable == null)
        {
            return;
        }

        damageable.TakeDamage(damage);
        remainingCooldown = cooldown;
    }
}
