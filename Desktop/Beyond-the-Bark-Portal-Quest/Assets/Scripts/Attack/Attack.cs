using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool IsAttacking => isAttacking;

    [SerializeField] private float damage = 20;
    [SerializeField] private string objetivoTag;

    private bool isAttacking = false;

    void OnTriggerEnter(Collider other)
    {
        if (isAttacking)
        {
            // Solo da�ar enemigos
            if (other.CompareTag(objetivoTag))
            {
                HealthBar healthBar = other.GetComponentInChildren<HealthBar>(true);
                if (healthBar != null)
                {
                    healthBar.DecreaseHealth(damage);
                }
                else
                {
                    Debug.Log($"{other.gameObject.name} no tiene componente Vida");
                }

                isAttacking = false;
            }

            
        }
    }

    public void ActivateDamage()
    {
        isAttacking = true;
    }

}