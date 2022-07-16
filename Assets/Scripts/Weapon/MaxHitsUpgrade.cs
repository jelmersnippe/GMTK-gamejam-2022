using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Max Hits", fileName = "New Max Hits Upgrade")]
public class MaxHitsUpgrade : Upgrade
{
    public int increase;
    public override void Apply(Weapon weapon)
    {
        weapon.projectile.maxHits += increase;
    }
}
