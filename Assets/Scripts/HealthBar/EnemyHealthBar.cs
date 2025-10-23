using UnityEngine;

public class EnemyHealthBar : MonoBehaviour, IDie
{
    private EnemyManager enemyManager; // Referencia al gestor de enemigos
    [SerializeField] private GameObject potionPrefab;
    [SerializeField][Range(0f, 1f)] private float DropProbability = 0.3f;

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


        if (potionPrefab != null)
        {
            
            if (Random.value <= DropProbability)
            {
              Instantiate(potionPrefab,transform.parent.parent.position,Quaternion.identity);
            }
        }


        Destroy(transform.parent.parent.gameObject);
    }
}