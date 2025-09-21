using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject keyPrefab; // El prefab de la llave que se instanciará.
    public Transform keySpawnPoint; 
    private int defeatedEnemies = 0;
    [SerializeField] private int enemiesToDefeat;

    public void EnemyDefeated()
    {
        defeatedEnemies++;
        Debug.Log("Enemigo derrotado. Total: " + defeatedEnemies);

        if (defeatedEnemies >= enemiesToDefeat)
        {
            Debug.Log("Todos los enemigos han sido derrotados. ¡Generando la llave!");
            SpawnKey();
            // Aquí puedes agregar la lógica para marcar el objetivo como completado.
        }
    }

    private void SpawnKey()
    {
        if (keyPrefab != null && keySpawnPoint != null)
        {
            Instantiate(keyPrefab, keySpawnPoint.position, Quaternion.identity);
            Debug.Log("Llave instanciada.");
        }
        else
        {
            Debug.LogError("El prefab de la llave o el punto de aparición no están asignados.");
        }
    }
}


