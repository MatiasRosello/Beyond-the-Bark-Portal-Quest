using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int keysCollected = 0; 

    public void AddKey()
    {
        keysCollected++;
        Debug.Log("Llave recogida, total de llaves: " +  keysCollected);
    }

    public bool HasKey()
    {
        return keysCollected > 0;
    }
}
