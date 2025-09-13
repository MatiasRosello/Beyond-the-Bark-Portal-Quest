using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool CanBeOpened
    {
        get => canBeOpened;
        set => canBeOpened = value;
    }

    private bool canBeOpened;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Open chest");
        }
    }
}