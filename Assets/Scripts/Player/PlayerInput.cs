using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Shooting))]
public class PlayerInput : MonoBehaviour
{
    public WeaponDice weaponDice;
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
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        movement.Move(movementInput);

        if (Input.GetMouseButtonDown(0))
        {
            shooting.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DiceOption<Weapon> weaponRoll = weaponDice.Roll();
            shooting.EquipWeapon(weaponRoll.value);
        }
    }
}
