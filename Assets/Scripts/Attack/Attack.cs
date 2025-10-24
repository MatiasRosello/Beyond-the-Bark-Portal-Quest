using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool IsAttacking => isAttacking;

    [SerializeField] private float damage = 20;
    [SerializeField] private float knockbackForce = 10f;
    [SerializeField] private string objetivoTag;

    private bool isAttacking = false;

    void OnTriggerEnter(Collider other)
    {
        if (isAttacking)
        {
            // Solo dañar enemigos
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

                // Aplicar knockback al enemigo
                ApplyKnockback(other.transform);

                isAttacking = false;
            }
        }
    }

    private void ApplyKnockback(Transform enemyTransform)
    {
        EnemyKnockback enemyKnockback = enemyTransform.GetComponent<EnemyKnockback>();
        if (enemyKnockback != null)
        {
            // Calcular dirección del knockback (del jugador al enemigo)
            Vector3 knockbackDirection = enemyTransform.position - transform.position;
            knockbackDirection.y = 0; // Opcional: mantener en plano horizontal
            knockbackDirection = knockbackDirection.normalized;

            // Llamar al método público del EnemyKnockback
            enemyKnockback.ApplyKnockback(knockbackDirection);
        }
        else
        {
            Debug.Log($"{enemyTransform.gameObject.name} no tiene componente EnemyKnockback");
        }
    }

    public void ActivateDamage()
    {
        isAttacking = true;
    }
}