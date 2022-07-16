using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Shots", fileName = "New Shots Upgrade")]
public class ProjectileCountUpgrade : Upgrade
{
    public int increase;
    public int spreadChange;

    public override void Apply(Weapon weapon)
    {
        weapon.shots += increase;
        weapon.spread += spreadChange;
    }
}
