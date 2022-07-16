using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth;
    // TODO: Change to IntReference, which can also be a constant!
    // ENEMIES REQUIRE A CONSTANT, BUT THE PLAYER NEEDS A REFERENCE
    // SO WE CAN HAVE THE UI AND CONTROLLERS READ THE OBJECT
    // ENEMIES DO NOT WANT A REFERENCE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [field: SerializeField] public int currentHealth { get; private set; }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth -= damage, 0, maxHealth);

        if (currentHealth <= 0)
        {
            // Disable collider to prevent unit soaking up bullets when already dead
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }
    }
}
