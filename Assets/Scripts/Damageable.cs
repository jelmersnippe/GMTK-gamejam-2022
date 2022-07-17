using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Damageable : MonoBehaviour
{
    public GameEvent OnHealthUpdate;
    public IntReference maxHealth;
    [field: SerializeField] public IntReference currentHealth { get; private set; }
    public HealthBar healthBar;
    public float invincibilityTime;
    public AudioSource audioSource;
    public Sound[] sounds;
    private Material initialMaterial;
    public Material hitFlashMaterial;
    public float hitFlashDuration = 0.15f;
    public SpriteRenderer spriteRenderer;

    private float remainingInvicibiltyTime;

    private void Start()
    {
        currentHealth.SetValue(maxHealth);
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
        healthBar?.SetFill((float)currentHealth / (float)maxHealth);
    }

    private IEnumerator ResetMaterial()
    {
        yield return new WaitForSeconds(hitFlashDuration);
        spriteRenderer.material = initialMaterial;
    }
}
