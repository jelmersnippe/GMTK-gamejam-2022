using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 5;
    public int maxHits = 1;
    public LayerMask targetMask;

    private int currentHits;
    private List<int> hitIds = new List<int>();

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int otherInstanceId = other.gameObject.GetInstanceID();
        if (hitIds.Contains(otherInstanceId) || targetMask != (targetMask | (1 << other.gameObject.layer)))
        {
            return;
        }

        Damageable damageable = other.gameObject.GetComponent<Damageable>();
        if (damageable == null)
        {
            return;
        }

        damageable.TakeDamage(damage);
        hitIds.Add(other.gameObject.GetInstanceID());
        currentHits++;

        if (currentHits >= maxHits)
        {
            Destroy(gameObject);
        }
    }
}
