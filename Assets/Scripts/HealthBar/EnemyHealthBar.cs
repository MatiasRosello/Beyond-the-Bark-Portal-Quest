using UnityEngine;

public class EnemyHealthBar : HealthBar, IDie
{
    private EnemyManager enemyManager;
    [SerializeField] private GameObject potionPrefab;
    [SerializeField][Range(0f, 1f)] private float dropProbability = 0.3f;
    [SerializeField] private EnemySoundController enemySoundController;

    protected override void Start()
    {
        base.Start();

        enemyManager = FindObjectOfType<EnemyManager>();
        if (enemyManager == null)
        {
            Debug.LogError("No hay script EnemyManager en la escena. Aseg�rate de que existe y est� activo.");
        }
    }


    public override void DecreaseHealth(float damageToTake)
    {
        

        currentHealth -= damageToTake; 

        
        if (enemySoundController != null)
        {
            enemySoundController.ZombieDamageSound();
        }

        UpdateHealthBar(); 

        if (currentHealth <= 0f)
        {
            Die(); 
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
            Vector3 spawnPosition = transform.parent.parent.position;
            spawnPosition.y = 0.25f;
            Instantiate(potionPrefab, spawnPosition, Quaternion.identity);
        }

        Destroy(transform.parent.parent.gameObject);
    }
}