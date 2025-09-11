using UnityEngine;

public class DogMove : MonoBehaviour
{
    public Transform objetivo;
    public float rango = 5f;
    public float distanciaMinima = 2f; // Distancia mínima a mantener
    public float velocidad = 3f;

    void Update()
    {
        if (objetivo == null) return;

        float posicion_Y = transform.position.y;

        // Calcular distancia entre el perro y el objetivo
        float distancia = Vector3.Distance(transform.position, objetivo.position);

        // Si está dentro del rango, mover hacia él
        if (distancia <= rango && distancia > distanciaMinima)
        {
            Vector3 direccion = (objetivo.position - transform.position).normalized;
            Vector3 nuevaPos = transform.position + direccion * velocidad * Time.deltaTime;
            nuevaPos.y = posicion_Y;
            transform.position = nuevaPos;
        }
    }
}