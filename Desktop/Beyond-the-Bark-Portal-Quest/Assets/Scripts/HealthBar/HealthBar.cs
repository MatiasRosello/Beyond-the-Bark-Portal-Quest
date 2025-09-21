using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float initialHealth;
    [SerializeField] private GameObject baseGameObject;

    private float currentHealth;
    private float maxHealth;
    private Image image;

    private void Awake()
    {
        image = GetComponentInChildren<Image>();
    }

    private void Start()
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
            GetComponent<IDie>().Die();
        }
    }

    public void ResetHealth()
    {
        currentHealth = initialHealth;
        image.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
    }
}
