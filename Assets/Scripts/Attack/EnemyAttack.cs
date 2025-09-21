using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    [SerializeField] private Transform player;

    private Animator animator;
    [SerializeField] private float rango = 1f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia <= rango)
        {
            sword.SetActive(true);
            animator.SetTrigger("SwordAttack");
            sword.GetComponent<Attack>().ActivateDamage();
        }
    }
}