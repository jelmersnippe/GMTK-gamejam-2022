using UnityEngine;
using TMPro;

public class DiceController : MonoBehaviour
{
    public WeaponDice weaponDice;
    public EnemyDice enemyDice;
    public UpgradeDice upgradeDice;

    public EnemyRuntimeSet enemiesToSpawn;
    public WeaponReference weaponToSpawn;
    public UpgradeRuntimeSet upgradesToApply;

    public DiceRowUI weaponDiceRowUI;
    public DiceRowUI enemyDiceRowUI;
    public DiceRowUI upgradeDiceRowUI;

    public TextMeshProUGUI roundText;
    public TextMeshProUGUI rollsRemainingUI;
    public IntReference currentRound;
    public IntReference rollsRemaining;

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        UpdateRollsRemaining(3);
        roundText.text = "Round: " + currentRound.Value;

        RollWeapon(false);
        RollEnemies(false);
        RollUpgrades(false);
    }

    public void RollWeapon(bool reduceRemainingRolls = true)
    {
        if (rollsRemaining <= 0)
        {
            return;
        }

        weaponDiceRowUI.Clear();

        DiceOption<Weapon> rolledWeapon = weaponDice.Roll();
        weaponToSpawn.value = rolledWeapon.value;
        weaponDiceRowUI.AddDiceUiItem(rolledWeapon.sprite);

        if (reduceRemainingRolls)
        {
            UpdateRollsRemaining(rollsRemaining.Value - 1);
        }
    }

    public void RollEnemies(bool reduceRemainingRolls = true)
    {
        if (rollsRemaining <= 0)
        {
            return;
        }

        enemiesToSpawn.Clear();
        enemyDiceRowUI.Clear();

        for (int i = 0; i < currentRound; i++)
        {
            DiceOption<Enemy> rolledEnemy = enemyDice.Roll();
            enemiesToSpawn.Add(rolledEnemy.value);
            enemyDiceRowUI.AddDiceUiItem(rolledEnemy.sprite);
        }

        if (reduceRemainingRolls)
        {
            UpdateRollsRemaining(rollsRemaining.Value - 1);
        }
    }

    public void RollUpgrades(bool reduceRemainingRolls = true)
    {
        if (rollsRemaining <= 0)
        {
            return;
        }

        upgradesToApply.Clear();
        upgradeDiceRowUI.Clear();

        for (int i = 0; i < currentRound; i++)
        {
            DiceOption<Upgrade> rolledUpgrade = upgradeDice.Roll();
            upgradesToApply.Add(rolledUpgrade.value);
            upgradeDiceRowUI.AddDiceUiItem(rolledUpgrade.sprite);
        }

        if (reduceRemainingRolls)
        {
            UpdateRollsRemaining(rollsRemaining.Value - 1);
        }
    }

    public void Roll()
    {
        RollWeapon();
        RollEnemies();
        RollUpgrades();
    }

    private void UpdateRollsRemaining(int newValue)
    {
        rollsRemaining.SetValue(newValue);
        rollsRemainingUI.text = "Rolls: " + newValue + "/3";

        weaponDiceRowUI.rollButton.interactable = rollsRemaining > 0;
        enemyDiceRowUI.rollButton.interactable = rollsRemaining > 0;
        upgradeDiceRowUI.rollButton.interactable = rollsRemaining > 0;
    }
}
