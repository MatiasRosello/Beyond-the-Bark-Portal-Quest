using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    [SerializeField] private Transform player;
    [SerializeField] private float rango = 1f;

    private Animator animator;
    private Attack attack;
    private bool canAttack = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        attack = sword.GetComponent<Attack>();
    }

    private void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia <= rango && canAttack)
        {
            sword.SetActive(true);
            animator.SetTrigger("SwordAttack");
            attack.ActivateDamage();

            canAttack = false;
            Invoke(nameof(AttackDelay), 0.8f);
        }
    }

    private void AttackDelay()
    {
        canAttack = true;
    }
}