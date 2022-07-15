using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth;
    public IntReference currentHealth;

    private void Start()
    {
        currentHealth.value = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth.value = Mathf.Clamp(currentHealth.value -= damage, 0, maxHealth);

        if (currentHealth.value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
