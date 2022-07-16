using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth;
    // TODO: Change to IntReference, which can also be a constant!
    // ENEMIES REQUIRE A CONSTANT, BUT THE PLAYER NEEDS A REFERENCE
    // SO WE CAN HAVE THE UI AND CONTROLLERS READ THE OBJECT
    // ENEMIES DO NOT WANT A REFERENCE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [field: SerializeField] public int currentHealth { get; private set; }
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth -= damage, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            // Disable collider to prevent unit soaking up bullets when already dead
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }
    }

    private void UpdateHealthBar()
    {
        healthBar?.SetFill((float)currentHealth / (float)maxHealth);
    }
}
