using UnityEngine;
using TMPro;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public GameObject keyPrefab; 
    public Transform keySpawnPoint; 
    private int defeatedEnemies = 0;
    [SerializeField] private int enemiesToDefeat;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private FirstLevelTutorialManager firstLevelTutorialManager;

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
                statusText.gameObject.SetActive(false);
                firstLevelTutorialManager.HasLlave = true;

            }
        }
    } 

}


