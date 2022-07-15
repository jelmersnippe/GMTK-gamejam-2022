using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform rotationCenter;
    public Weapon startingWeapon;
    private Weapon activeWeapon;

    private void Start()
    {
        if (startingWeapon != null && activeWeapon == null)
        {
            EquipWeapon(startingWeapon);
        }
    }

    public void Shoot()
    {
        if (activeWeapon == null)
        {
            return;
        }

        activeWeapon.Fire();
    }

    public void EquipWeapon(Weapon weapon)
    {
        activeWeapon = Instantiate(weapon, rotationCenter);
    }
}
