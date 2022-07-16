using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Firerate", fileName = "New Firerate Upgrade")]
public class FirerateUpgrade : Upgrade
{
    public float increase;

    public override void Apply(Weapon weapon)
    {
        weapon.fireRate += increase;
    }
}
