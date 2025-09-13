using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private GameObject sword;

    private bool canAttack;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TurnOnSword()
    {
        sword.SetActive(true);
        canAttack = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            animator.SetTrigger("SwordAttack");
        }
    }
}
