using UnityEngine;
using TMPro;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public GameObject keyPrefab; // El prefab de la llave que se instanciará.
    public Transform keySpawnPoint; 
    private int defeatedEnemies = 0;
    [SerializeField] private int enemiesToDefeat;
    [SerializeField] private TextMeshProUGUI statusText;

    public void EnemyDefeated()
    {
        
        if (defeatedEnemies == 0)
        {
            statusText.gameObject.SetActive(true);
        }

        defeatedEnemies++;
        Debug.Log("Enemigo derrotado. Total: " + defeatedEnemies);

        UpdateUIText();

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

    private void UpdateUIText()
    {
        if (statusText != null)
        {
            if (defeatedEnemies < enemiesToDefeat)
            {
                statusText.text = "Enemigos muertos " + defeatedEnemies + "/" + enemiesToDefeat;
            }
            else
            {
                statusText.text = "Todos los enemigos han muerto, recoge la llave para avanzar.";

                StartCoroutine(HideTextAfterDelay(3f));
            }
        }
    }

    // Coroutine para ocultar el texto
    private IEnumerator HideTextAfterDelay(float delay)
    {
        // Espera 'delay' segundos antes de continuar
        yield return new WaitForSeconds(delay);

        // Desactiva el objeto de texto, haciéndolo invisible
        if (statusText != null)
        {
            statusText.gameObject.SetActive(false);
        }
    }



}


