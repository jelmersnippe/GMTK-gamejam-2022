using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    public WeaponDice weaponDice;
    public EnemyDice enemyDice;

    public EnemyRuntimeSet enemiesToSpawn;
    public WeaponReference weaponToSpawn;

    public DiceRowUI weaponDiceRowUI;
    public DiceRowUI enemyDiceRowUI;

    public Button rollButton;
    public Button startButton;

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        enemiesToSpawn.Clean();
        weaponDiceRowUI.Clear();
        enemyDiceRowUI.Clear();
        rollButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
    }

    public void RollWeapon()
    {
        weaponDiceRowUI.Clear();

        DiceOption<Weapon> rolledWeapon = weaponDice.Roll();
        weaponToSpawn.value = rolledWeapon.value;
        weaponDiceRowUI.AddDiceUiItem(rolledWeapon.sprite);
    }

    public void RollEnemies(int count)
    {
        enemyDiceRowUI.Clear();
        for (int i = 0; i < count; i++)
        {
            DiceOption<Enemy> rolledEnemy = enemyDice.Roll();
            enemiesToSpawn.Add(rolledEnemy.value);
            enemyDiceRowUI.AddDiceUiItem(rolledEnemy.sprite);
        }
    }

    public void Roll(int enemyCount)
    {
        RollWeapon();
        RollEnemies(enemyCount);
        rollButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
    }
}
