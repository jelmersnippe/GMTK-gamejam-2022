using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Shooting))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerInput : MonoBehaviour
{
    public Movement movement;
    public Shooting shooting;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (movement == null)
        {
            movement = GetComponent<Movement>();
        }
        if (shooting == null)
        {
            shooting = GetComponent<Shooting>();
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Time.timeScale <= 0f)
        {
            return;
        }

        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        shooting.RotateWeaponToTarget(MousePosition.Get());

        Vector3 mousePosition = MousePosition.Get();
        float targetAngle = Mathf.Abs(Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg);
        spriteRenderer.flipX = targetAngle > 90f && targetAngle < 270f;

        movement.Move(movementInput);

        if (Input.GetMouseButton(0))
        {
            shooting.Shoot();
        }
    }
}
