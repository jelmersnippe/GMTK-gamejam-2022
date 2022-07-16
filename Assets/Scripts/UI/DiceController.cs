using System.Collections.Generic;
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

    public List<DiceOption<Enemy>> rolledEnemies = new List<DiceOption<Enemy>>();
    public List<DiceOption<Upgrade>> rolledUpgrades = new List<DiceOption<Upgrade>>();

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
        roundText.text = "Round: " + currentRound.Value;

        while (currentRound > rolledEnemies.Count)
        {
            DiceOption<Enemy> rolledEnemy = enemyDice.Roll();
            enemyDiceRowUI.UpdateDiceUiItem(rolledEnemies.Count, rolledEnemy.sprite);
            rolledEnemies.Add(rolledEnemy);
        }

        while (currentRound > rolledUpgrades.Count)
        {
            DiceOption<Upgrade> rolledUpgrade = upgradeDice.Roll();
            upgradeDiceRowUI.UpdateDiceUiItem(rolledUpgrades.Count, rolledUpgrade.sprite);
            rolledUpgrades.Add(rolledUpgrade);
        }

        RollWeapon();

        UpdateRollsRemaining(3);
    }

    public void RollWeapon()
    {
        if (rollsRemaining <= 0 || (weaponDiceRowUI.diceContainer.childCount > 0 && weaponDiceRowUI.diceContainer.GetChild(0).GetComponent<DieUI>().locked))
        {
            return;
        }

        weaponDiceRowUI.Clear();

        DiceOption<Weapon> rolledWeapon = weaponDice.Roll();
        weaponToSpawn.value = rolledWeapon.value;
        weaponDiceRowUI.UpdateDiceUiItem(0, rolledWeapon.sprite);

        UpdateRollsRemaining(rollsRemaining.Value - 1);
    }

    public void RollEnemies()
    {
        if (rollsRemaining <= 0)
        {
            return;
        }

        for (int i = 0; i < rolledEnemies.Count; i++)
        {
            if (enemyDiceRowUI.diceContainer.GetChild(i).GetComponent<DieUI>().locked)
            {
                continue;
            }

            DiceOption<Enemy> rolledEnemy = enemyDice.Roll();
            rolledEnemies[i] = rolledEnemy;
            enemyDiceRowUI.UpdateDiceUiItem(i, rolledEnemy.sprite);
        }

        UpdateRollsRemaining(rollsRemaining.Value - 1);
    }

    public void RollUpgrades()
    {
        if (rollsRemaining <= 0)
        {
            return;
        }

        for (int i = 0; i < rolledUpgrades.Count; i++)
        {
            if (upgradeDiceRowUI.diceContainer.GetChild(i).GetComponent<DieUI>().locked)
            {
                continue;
            }

            DiceOption<Upgrade> rolledUpgrade = upgradeDice.Roll();
            rolledUpgrades[i] = rolledUpgrade;
            upgradeDiceRowUI.UpdateDiceUiItem(i, rolledUpgrade.sprite);
        }

        UpdateRollsRemaining(rollsRemaining.Value - 1);
    }

    private void UpdateRollsRemaining(int newValue)
    {
        rollsRemaining.SetValue(newValue);
        rollsRemainingUI.text = "Rolls: " + newValue + "/3";

        weaponDiceRowUI.rollButton.interactable = rollsRemaining > 0;
        enemyDiceRowUI.rollButton.interactable = rollsRemaining > 0;
        upgradeDiceRowUI.rollButton.interactable = rollsRemaining > 0;
    }

    public void ConfirmRolls()
    {
        enemiesToSpawn.Clear();
        foreach (DiceOption<Enemy> enemyRoll in rolledEnemies)
        {
            enemiesToSpawn.Add(enemyRoll.value);
        }

        upgradesToApply.Clear();
        foreach (DiceOption<Upgrade> upgradeRoll in rolledUpgrades)
        {
            upgradesToApply.Add(upgradeRoll.value);
        }
    }
}
