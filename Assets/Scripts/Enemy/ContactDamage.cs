using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public int damage;
    public LayerMask targetMask;

    private void OnCollisionStay2D(Collision2D other)
    {
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
    }
}
