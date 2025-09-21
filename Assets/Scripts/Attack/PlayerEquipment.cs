using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private GameObject sword;

    private bool canAttack;
    private Animator animator;
    [SerializeField] private PlayerSoundController soundController;
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
            sword.GetComponent<Daniar>().ActivateDamage();
            soundController.attackSound();
        }
    }
}
