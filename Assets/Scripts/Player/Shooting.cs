using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform rotationCenter;
    [SerializeField] private Weapon activeWeapon;
    public UpgradeRuntimeSet upgradesToApply;

    public void RotateWeaponToTarget(Vector3 target)
    {
        if (Time.timeScale <= 0f)
        {
            return;
        }

        float angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg;
        rotationCenter.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        float absoluteAngle = Mathf.Abs(angle);
        activeWeapon.spriteRenderer.flipY = absoluteAngle > 90f && absoluteAngle < 270f;
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
        EquipWeapon(weapon.value);
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (activeWeapon != null)
        {
            Destroy(activeWeapon.gameObject);
        }
        activeWeapon = Instantiate(weapon, rotationCenter);

        foreach (Upgrade upgrade in upgradesToApply.items)
        {
            upgrade.Apply(activeWeapon);
        }
    }
}
