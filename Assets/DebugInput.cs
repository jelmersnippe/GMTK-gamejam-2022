using UnityEngine;

public class DebugInput : MonoBehaviour
{
    public DiceController diceController;
    public int enemyRollCount = 1;
    public int weaponRollCount = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            diceController.RollEnemies(enemyRollCount);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            diceController.RollWeapons(weaponRollCount);
        }
    }
}
