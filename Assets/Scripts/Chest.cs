using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool CanBeOpened
    {
        get => canBeOpened;
        set => canBeOpened = value;
    }

    private bool canBeOpened;
    private bool opened;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !opened)
        {
            opened = true;
            FirstLevelTutorialManager.Instance.HasOpenedChest = true;
            animator.SetTrigger("Open");
        }
    }
}