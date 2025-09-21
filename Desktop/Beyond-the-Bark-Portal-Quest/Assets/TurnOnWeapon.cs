using UnityEngine;

public class TurnOnWeapon : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    [SerializeField] private PlayerSoundController soundController;

    private bool isAttacking;
    private bool isSwordActive = false;
    private bool canEquip = true; 
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
       
        sword.SetActive(false);
    }

    public void TurnOnSword()
    {
        sword.SetActive(true);
        isSwordActive = true;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && canEquip)
        {
            TurnOnSword(); 
            canEquip = false; 
        }

        if (Input.GetMouseButtonDown(0) && isSwordActive && !isAttacking)
        {
            animator.SetTrigger("SwordAttack");
            sword.GetComponent<Attack>().ActivateDamage();
            soundController.attackSound();

            
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

