using UnityEngine;

public class EnemyHealthBar : HealthBar, IDie
{
    private EnemyManager enemyManager;
    [SerializeField] private GameObject potionPrefab;
    [SerializeField][Range(0f, 1f)] private float dropProbability = 0.3f;

    protected override void Start()
    {
        base.Start();

        enemyManager = FindObjectOfType<EnemyManager>();
        if (enemyManager == null)
        {
            Debug.LogError("No hay script EnemyManager en la escena. Asegúrate de que existe y está activo.");
        }
    }

    public override void Die()
    {
        if (enemyManager != null)
        {
            enemyManager.EnemyDefeated();
        }

        if (potionPrefab != null && Random.value <= dropProbability)
        {
            Instantiate(potionPrefab, transform.parent.parent.position, Quaternion.identity);
        }

        Destroy(transform.parent.parent.gameObject);
    }
}