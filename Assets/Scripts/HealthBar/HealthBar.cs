using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IDie
{
    [SerializeField] protected float initialHealth;
    [SerializeField] protected GameObject baseGameObject;

    protected float currentHealth; 
    protected float maxHealth;
    protected Image image;

    protected virtual void Awake()
    {
        image = GetComponentInChildren<Image>();
    }

    protected virtual void Start()
    {
        maxHealth = initialHealth;
        currentHealth = initialHealth;
    }

    public void DecreaseHealth(float damageToTake)
    {
        currentHealth -= damageToTake;
        image.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public virtual void ResetHealth()
    {
        currentHealth = initialHealth;
        image.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
    }

    public void IncreaseHealth(float amountToHeal)
    {
        currentHealth += amountToHeal;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        image.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
    }

    public virtual void Die()
    {

    }
}