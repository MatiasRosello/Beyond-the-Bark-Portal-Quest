using UnityEngine;

public class EnemyHealthBar : MonoBehaviour, IDie
{
    public void Die()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}