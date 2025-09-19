using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] private int vidaMaxima = 100;
    [SerializeField] private int vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    public void Curar(int cantidad)
    {
        vidaActual += cantidad;

        // la vida no debe superar al maximo
        vidaActual = Mathf.Min(vidaActual, vidaMaxima);
    }

    private void Morir()
    {
        Destroy(gameObject);
    }
}