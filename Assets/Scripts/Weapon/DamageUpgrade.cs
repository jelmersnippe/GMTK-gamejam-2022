using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Damage", fileName = "New Damage Upgrade")]
public class DamageUpgrade : Upgrade
{
    public int increase;

    public override void Apply(Weapon weapon)
    {
        weapon.damage += increase;
    }
}
