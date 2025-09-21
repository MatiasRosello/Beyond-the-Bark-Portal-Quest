using UnityEngine;

public class EnemyHealthBar : MonoBehaviour, IDie
{
    private EnemyManager enemyManager; // Referencia al gestor de enemigos

    void Start()
    {
        // Busca el objeto que tiene el script EnemyManager.
        enemyManager = FindObjectOfType<EnemyManager>();
        if (enemyManager == null)
        {
            Debug.LogError("No hay script EnemyManager en la escena. Asegúrate de que existe y está activo.");
        }
    }

    public void Die()
    {
        
        if (enemyManager != null)
        {
            enemyManager.EnemyDefeated();
        }

        
        Destroy(transform.parent.parent.gameObject);
    }
}