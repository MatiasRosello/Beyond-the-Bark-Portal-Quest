using UnityEngine;

public class DogMove : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private float distanciaLateral = 1.5f; // Distancia al costado izquierdo
    [SerializeField] private float velocidad = 3f;

    void Update()
    {
        if (objetivo == null) return;

        // Calcular la posición objetivo (a la izquierda del jugador en la misma línea horizontal)
        Vector3 posicionObjetivo = new Vector3(
            objetivo.position.x - distanciaLateral,
            transform.position.y, // Mantener la altura actual del perro
            objetivo.position.z
        );

        // Mover suavemente hacia la posición objetivo
        transform.position = Vector3.MoveTowards(
            transform.position,
            posicionObjetivo,
            velocidad * Time.deltaTime
        );

        // Opcional: Hacer que el perro mire hacia el jugador
        if (transform.position.x < objetivo.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // Método para visualizar en el editor
    void OnDrawGizmosSelected()
    {
        if (objetivo != null)
        {
            Vector3 posicionObjetivo = new Vector3(
                objetivo.position.x - distanciaLateral,
                transform.position.y,
                objetivo.position.z
            );

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(posicionObjetivo, 0.3f);
            Gizmos.DrawLine(objetivo.position, posicionObjetivo);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, posicionObjetivo);
        }
    }
}