using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform rotationCenter;
    [SerializeField] private Weapon activeWeapon;

    public void RotateWeaponToTarget(Vector3 target)
    {
        if (Time.timeScale <= 0f)
        {
            return;
        }

        float angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg;
        rotationCenter.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

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
