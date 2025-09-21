using UnityEngine;
using TMPro;
using System.Collections;

public class ThirdLevelManager : MonoBehaviour

{
public GameObject BossPrefab;
public Transform BossSpawnPoint;
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
        Debug.Log("Todos los enemigos han sido derrotados. ¡Un jefe está en camino!");
        SpawnBoss();

    }
}

private void SpawnBoss()
{
    if (BossPrefab != null && BossSpawnPoint != null)
    {
        Instantiate(BossPrefab, BossSpawnPoint.position, Quaternion.identity);
        Debug.Log("Aparece un boss.");
    }
    else
    {
        Debug.LogError("El prefab del boss o el punto de aparición no están asignados.");
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
            statusText.text = "Todos los enemigos han sido derrotados. ¡Un jefe está en camino!\"";

            StartCoroutine(HideTextAfterDelay(3f));
        }
    }
}

// Coroutine para ocultar el texto//


private IEnumerator HideTextAfterDelay(float delay)
{

    yield return new WaitForSeconds(delay);


    if (statusText != null)
    {
        statusText.gameObject.SetActive(false);
    }
}

    

}