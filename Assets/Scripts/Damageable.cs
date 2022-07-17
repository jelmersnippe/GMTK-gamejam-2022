using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Damageable : MonoBehaviour
{
    public GameEvent OnHealthUpdate;
    public IntReference maxHealth;
    private int activeMaxHealth;
    [field: SerializeField] public IntReference currentHealth { get; private set; }
    public HealthBar healthBar;
    public float invincibilityTime;
    public AudioSource audioSource;
    public Sound[] sounds;
    private Material initialMaterial;
    public Material hitFlashMaterial;
    public float hitFlashDuration = 0.15f;
    public SpriteRenderer spriteRenderer;
    public DamageNumber damageNumber;

    private float remainingInvicibiltyTime;

    private void Awake()
    {
        activeMaxHealth = maxHealth;
        currentHealth.SetValue(activeMaxHealth);
    }

    private void Start()
    {
        OnHealthUpdate.Raise();
        UpdateHealthBar();
        initialMaterial = spriteRenderer.material;
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

        if (sounds.Length > 0)
        {
            int soundsIndex = Random.Range(0, sounds.Length);
            AudioManager.PlaySound(audioSource, sounds[soundsIndex]);
        }

        if (damageNumber != null)
        {
            DamageNumber popup = Instantiate(damageNumber, transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);
            popup.SetDamage(damage);
        }

        spriteRenderer.material = hitFlashMaterial;
        StartCoroutine(ResetMaterial());
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
        healthBar?.SetFill((float)currentHealth / (float)activeMaxHealth);
    }

    private IEnumerator ResetMaterial()
    {
        yield return new WaitForSeconds(hitFlashDuration);
        spriteRenderer.material = initialMaterial;
    }

    public void UpdateMaxHealth(int change)
    {
        activeMaxHealth += change;
        currentHealth.ApplyChange(change);
        UpdateHealthBar();
    }
}
