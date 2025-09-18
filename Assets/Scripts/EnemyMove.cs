using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private float rango = 5f;
    [SerializeField] private float distanciaMinima = 2f; // Distancia minima a mantener
    [SerializeField] private float velocidad = 3f;
    [SerializeField] private float velocidadRotacion = 5f; // Velocidad de rotación

    void Update()
    {
        if (objetivo == null) return;

        float posicion_Y = transform.position.y;

        float distancia = Vector3.Distance(transform.position, objetivo.position);

        // Si esta dentro del rango, mover hacia el
        if (distancia <= rango && distancia > distanciaMinima)
        {
            Vector3 direccion = (objetivo.position - transform.position).normalized;
            Vector3 nuevaPos = transform.position + direccion * velocidad * Time.deltaTime;
            nuevaPos.y = posicion_Y;
            transform.position = nuevaPos;

            // rotar para quedar enfrentado al player
            RotarHaciaObjetivo();
        }
    }

    void RotarHaciaObjetivo()
    {
        // calcular la dirección hacia el objetivo
        Vector3 direccion = objetivo.position - transform.position;
        direccion.y = 0; // mantener la rotación solo en el eje Y

        // rotar
        if (direccion != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo,
                velocidadRotacion * Time.deltaTime);
        }
    }
}