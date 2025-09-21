using UnityEngine;

public class BarGates : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que colisiona es el jugador.
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            // Si el jugador tiene el script de inventario...
            if (playerInventory != null)
            {
                // ...y tiene al menos una llave...
                if (playerInventory.HasKey())
                {
                    Debug.Log("¡Barrotes abiertos!");
                    // Destruye los barrotes.
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
