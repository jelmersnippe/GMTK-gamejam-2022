using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public TextMeshProUGUI roundText;
    public IntReference currentRound;

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        enemiesToSpawn.Clear();
        weaponDiceRowUI.Clear();
        enemyDiceRowUI.Clear();
        rollButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        roundText.text = "Round: " + currentRound.value;

        weaponDiceRowUI.AddDiceUiItem(null);
        for (int i = 0; i < currentRound.value; i++)
        {
            enemyDiceRowUI.AddDiceUiItem(null);
        }
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

    public void Roll()
    {
        RollWeapon();
        RollEnemies(currentRound.value);
        rollButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
    }
}
