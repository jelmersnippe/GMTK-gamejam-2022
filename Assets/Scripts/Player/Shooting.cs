using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform rotationCenter;
    private Weapon activeWeapon;

    public void Shoot()
    {
        if (activeWeapon == null)
        {
            return;
        }

        activeWeapon.Fire();
    }

    public void EquipWeapon(WeaponReference weapon)
    {
        activeWeapon = Instantiate(weapon.value, rotationCenter);
    }

    public void EquipWeapon(Weapon weapon)
    {
        activeWeapon = Instantiate(weapon, rotationCenter);
    }
}
