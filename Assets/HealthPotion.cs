using UnityEngine;

public class HealthPotion : MonoBehaviour
{

    [SerializeField] private float lifeToHeal = 25f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthBar healthBarDelPlayer = other.GetComponent<HealthBar>();

            if (healthBarDelPlayer != null)
            {
                healthBarDelPlayer.IncreaseHealth(lifeToHeal);
                Destroy(gameObject);
            }
        }
    }
}
