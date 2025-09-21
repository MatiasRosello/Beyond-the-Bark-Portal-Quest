using UnityEngine;

public class BarGates : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            
            if (playerInventory != null)
            {
                
                if (playerInventory.HasKey())
                {
                    Debug.Log("¡Barrotes abiertos!");
                   
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("El jugador no tiene la llave para abrir los barrotes.");
                }
            }
        }
    }
}
