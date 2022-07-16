using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Shooting))]
public class PlayerInput : MonoBehaviour
{
    public Movement movement;
    public Shooting shooting;

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
    }

    private void Update()
    {
        if (Time.timeScale <= 0f)
        {
            return;
        }

        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        movement.Move(movementInput);

        if (Input.GetMouseButtonDown(0))
        {
            shooting.Shoot();
        }
    }
}
