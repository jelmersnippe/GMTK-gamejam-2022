using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public WeaponDice weaponDice;
    public EnemyDice enemyDice;

    public List<DiceOption<Weapon>> weaponRolls = new List<DiceOption<Weapon>>();
    public List<DiceOption<Enemy>> enemyRolls = new List<DiceOption<Enemy>>();

    public DiceRowUI weaponDiceRowUI;
    public DiceRowUI enemyDiceRowUI;

    public void RollWeapons(int count)
    {
        weaponDiceRowUI.Clear();
        for (int i = 0; i < count; i++)
        {
            DiceOption<Weapon> rolledWeapon = weaponDice.Roll();
            weaponRolls.Add(rolledWeapon);
            weaponDiceRowUI.AddDiceUiItem(rolledWeapon.sprite);
        }
    }

    public void RollEnemies(int count)
    {
        enemyDiceRowUI.Clear();
        for (int i = 0; i < count; i++)
        {
            DiceOption<Enemy> rolledEnemy = enemyDice.Roll();
            enemyRolls.Add(rolledEnemy);
            enemyDiceRowUI.AddDiceUiItem(rolledEnemy.sprite);
        }
    }
}
