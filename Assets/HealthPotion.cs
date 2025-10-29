using UnityEngine;

public class HealthPotion : MonoBehaviour
{

    [SerializeField] private float lifeToHeal = 25f;
    [SerializeField] private PotionSoundController soundController;

    private void Start()
    {
        // Si tiene Rigidbody, usar MovePosition en lugar de transform.position
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 newPosition = new Vector3(transform.position.x, 0.25f, transform.position.z);
            rb.MovePosition(newPosition);
        }
        else
        {
            // Si no tiene Rigidbody, usar el método normal
            transform.position = new Vector3(transform.position.x, 0.25f, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthBar playerHealthBar = other.GetComponentInChildren<HealthBar>();

            if (playerHealthBar != null)
            {
                playerHealthBar.IncreaseHealth(lifeToHeal);
                if (soundController != null)
                {
                    soundController.pickUpPotionSound();
                }
                GetComponent<Collider>().enabled = false;
                GetComponent<Renderer>().enabled = false;
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
