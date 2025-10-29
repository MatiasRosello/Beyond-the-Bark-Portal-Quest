using UnityEngine;

public class HealthBar : MonoBehaviour, IDie
{
    [SerializeField] protected float initialHealth;
    [SerializeField] protected GameObject baseGameObject;
    [SerializeField] protected GameObject healthBarCube;
    [SerializeField] protected bool reduceFromLeft = true;
    [SerializeField] private PlayerSoundController soundController;

    protected float currentHealth;
    protected float maxHealth;
    protected Vector3 originalScale;
    protected Vector3 originalPosition;

    protected virtual void Awake()
    {
        if (healthBarCube != null)
        {
            originalScale = healthBarCube.transform.localScale;
            originalPosition = healthBarCube.transform.localPosition;
        }
    }

    protected virtual void Start()
    {
        maxHealth = initialHealth;
        currentHealth = initialHealth;
        UpdateHealthBar();
    }

    public virtual void DecreaseHealth(float damageToTake)
    {
        currentHealth -= damageToTake;
        if (soundController != null)
        {
            soundController.damageSound();
        }
        UpdateHealthBar();


        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public virtual void ResetHealth()
    {
        currentHealth = initialHealth;
        UpdateHealthBar();
    }

    public void IncreaseHealth(float amountToHeal)
    {
        currentHealth += amountToHeal;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();
    }
    protected virtual void UpdateHealthBar()
    {
        if (healthBarCube != null)
        {
            float healthPercentage = Mathf.Clamp01(currentHealth / maxHealth);
            Vector3 newScale = new Vector3(originalScale.x * healthPercentage, originalScale.y, originalScale.z);
            healthBarCube.transform.localScale = newScale;

            float positionOffset = (originalScale.x - newScale.x) / 2f;
            Vector3 newPosition;

            if (reduceFromLeft)
            {
                // Reducir hacia la izquierda
                newPosition = new Vector3(
                    originalPosition.x - positionOffset,
                    originalPosition.y,
                    originalPosition.z
                );
            }
            else
            {
                // Reducir hacia la derecha
                newPosition = new Vector3(
                    originalPosition.x + positionOffset,
                    originalPosition.y,
                    originalPosition.z
                );
            }

            healthBarCube.transform.localPosition = newPosition;
        }
    }

    public virtual void Die()
    {

    }
}