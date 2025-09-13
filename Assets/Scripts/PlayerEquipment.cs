using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private GameObject sword;

    public void TurnOnSword()
    {
        sword.SetActive(true);
    }
}
