using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float damage = 20;
    [SerializeField] private string objetivoTag;
    
    private bool estaAtacando = false;

    void OnTriggerEnter(Collider other)
    {
        if (estaAtacando)
        {
            // Solo da�ar enemigos
            if (other.CompareTag(objetivoTag))
            {
                HealthBar healthBar = other.GetComponentInChildren<HealthBar>(true);
                if (healthBar != null)
                {
                    healthBar.DecreaseHealth(damage);
                }
                else
                {
                    Debug.Log($"{other.gameObject.name} no tiene componente Vida");
                }

                estaAtacando = false;
            }

            
        }
    }

    public void ActivateDamage()
    {
        estaAtacando = true;
    }

}