using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ContactDamage))]
public class ChaseBehaviour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public ContactDamage contactDamage;
    public float speed = 4f;
    public Transform target;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        contactDamage = GetComponent<ContactDamage>();
    }

    void Update()
    {
        if (target != null)
        {
            if (contactDamage.remainingCooldown <= 0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            float targetAngle = Mathf.Abs(Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg);
            spriteRenderer.flipX = targetAngle > 90f && targetAngle < 270f;
        }
    }
}
