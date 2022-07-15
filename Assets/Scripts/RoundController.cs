using UnityEngine;

public class RoundController : MonoBehaviour
{
    public EnemyRuntimeSet activeEnemies;
    public IntReference playerHealth;
    public Spawner spawner;
    public Shooting shooting;
    public WeaponReference weaponToEquip;

    private void Update()
    {
        // TODO: Should listen to an enemy death event instead for performance
        if (activeEnemies.items.Count <= 0 || playerHealth.value <= 0)
        {
            // TODO: Should perform round logic -> end round event, which enables the dicerollui for the next round
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("No active enemies!");
        }
    }

    public void StartRound()
    {
        spawner.Spawn();
        shooting.EquipWeapon(weaponToEquip.value);
    }
}
