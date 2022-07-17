using UnityEngine;

public class HUDController : MonoBehaviour
{
    public IntReference maxPlayerHealth;
    public IntReference currentPlayerHealth;
    public HealthBar playerHealthBar;

    private void OnEnable()
    {
        UpdatePlayerHealthBar();
    }

    public void UpdatePlayerHealthBar()
    {
        playerHealthBar.SetFill(currentPlayerHealth.Value, maxPlayerHealth.Value);
    }
}
