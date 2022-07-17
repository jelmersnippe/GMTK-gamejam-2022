using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChaseBehaviour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float speed = 4f;
    public Transform target;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            float targetAngle = Mathf.Abs(Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg);
            spriteRenderer.flipX = targetAngle > 90f && targetAngle < 270f;
        }
    }
}
