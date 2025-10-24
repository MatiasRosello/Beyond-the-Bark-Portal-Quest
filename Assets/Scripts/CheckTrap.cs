using UnityEngine;

public class CheckTrap : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;

    private void Awake()
    {
        if (healthBar == null)
            healthBar = GetComponent<HealthBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            healthBar.Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            healthBar.Die();
        }
    }
}