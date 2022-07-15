using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour
{
    public EnemyRuntimeSet activeEnemies;
    public IntReference playerHealth;

    void Update()
    {
        // TODO: Should listen to an enemy death event instead for performance
        if (activeEnemies.items.Count <= 0 || playerHealth.value <= 0)
        {
            // TODO: Should perform round logic
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("No active enemies!");
        }
    }
}
