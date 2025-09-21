using UnityEngine;

public class PlayerHealthBar : MonoBehaviour, IDie
{
    public void Die()
    {
        print("Player is dead");
    }
}