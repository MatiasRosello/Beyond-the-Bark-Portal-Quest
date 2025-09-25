using UnityEngine;

public class CheckTrap : MonoBehaviour
{
    [SerializeField] private PlayerHealthBar playerHealthBar;

    private void Awake()
    {
        if (playerHealthBar == null)
            playerHealthBar = GetComponent<PlayerHealthBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            playerHealthBar.Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            playerHealthBar.Die();
        }
    }
}