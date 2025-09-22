using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    [SerializeField] private PlayerSoundController soundController;
    [SerializeField] private bool turnOnSwordOnStart;

    private bool isAttacking;
    private bool isSwordActive;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (turnOnSwordOnStart)
        {
            TurnOnSword();
        }
    }

    public void TurnOnSword()
    {
        sword.SetActive(true);
        isSwordActive = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isSwordActive && !isAttacking)
        {
            animator.SetTrigger("SwordAttack");
            sword.GetComponent<Attack>().ActivateDamage();
            soundController.attackSound();

            isAttacking = false;
        }
    }

    public void CanAttack_AnimationEvent()
    {
        print("True");
        isAttacking = true;
    }

    public void CannotAttack_AnimationEvent()
    {
        print("False");
        isAttacking = false;
    }
}
