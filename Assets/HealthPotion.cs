using UnityEngine;

public class HealthPotion : MonoBehaviour
{

    [SerializeField] private float lifeToHeal = 25f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthBar playerHealthBar = other.GetComponentInChildren<HealthBar>();

            if (playerHealthBar != null)
            {
                playerHealthBar.IncreaseHealth(lifeToHeal);
                Destroy(gameObject);
            }
        }
    }
}
