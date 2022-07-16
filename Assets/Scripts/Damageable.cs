using UnityEngine;

public class Damageable : MonoBehaviour
{
    public GameEvent OnHealthUpdate;
    public IntReference maxHealth;
    [field: SerializeField] public IntReference currentHealth { get; private set; }
    public HealthBar healthBar;
    public float invincibilityTime;

    private float remainingInvicibiltyTime;

    private void Start()
    {
        currentHealth.SetValue(maxHealth);
        OnHealthUpdate.Raise();
        UpdateHealthBar();
    }

    private void Update()
    {
        if (remainingInvicibiltyTime > 0f)
        {
            remainingInvicibiltyTime -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        if (remainingInvicibiltyTime > 0f)
        {
            return;
        }

        currentHealth.ApplyChange(-damage);
        remainingInvicibiltyTime = invincibilityTime;
        OnHealthUpdate.Raise();
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
