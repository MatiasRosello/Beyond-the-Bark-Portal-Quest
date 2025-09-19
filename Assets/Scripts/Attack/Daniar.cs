using UnityEngine;

public class Daniar : MonoBehaviour
{
    [SerializeField] private int daño = 20;
    [SerializeField] private string objetivoTag;
    private bool estaAtacando = false;

    void OnTriggerEnter(Collider other)
    {
        if (estaAtacando)
        {
            // Solo dañar enemigos
            if (other.CompareTag(objetivoTag))
            {
                Vida vidaObjetivo = other.GetComponent<Vida>();
                if (vidaObjetivo != null)
                {
                    vidaObjetivo.RecibirDanio(daño);
                    Debug.Log($"Daño {daño} a {other.gameObject.name}");
                }
                else
                {
                    Debug.Log($"{other.gameObject.name} no tiene componente Vida");
                }

                estaAtacando = false;
            }

            
        }
    }

    public void ActivarDaño()
    {
        estaAtacando = true;
    }

}