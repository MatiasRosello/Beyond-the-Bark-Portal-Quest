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

                // Aplicar knockback
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
            knockbackDirection.y = 0;
            knockbackDirection = knockbackDirection.normalized;

            // método público del enemyKnockback
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