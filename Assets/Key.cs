using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que colisiona es el jugador.
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            
            if (playerInventory != null)
            {
                playerInventory.AddKey();
            }

            Debug.Log("Llave recogida!");
            // Destruye el objeto de la llave una vez que el jugador la recoge.
            Destroy(gameObject);

            // Aquí puedes agregar la lógica para actualizar el inventario del jugador,
            // cambiar un estado del juego, etc.
        }
    }
}
