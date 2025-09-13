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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !opened)
        {
            opened = true;
            FirstLevelTutorialManager.Instance.HasOpenedChest = true;
        }
    }
}