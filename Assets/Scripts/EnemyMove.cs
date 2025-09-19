using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private float rango = 5f;
    [SerializeField] private float distanciaMinima = 2f;
    [SerializeField] private float velocidad = 3f;
    [SerializeField] private float velocidadRotacion = 5f;
    [SerializeField] private string paredTag = "Pared";
    [SerializeField] private float distanciaDeteccion = 7f;
    [SerializeField] private float umbralLlegada = 0.1f; // umbral para llegar a la posición inicial

    private Vector3 posicionInicial;
    private bool regresando = false;

    void Start()
    {
        // Guardar la posición inicial al iniciar
        posicionInicial = transform.position;
    }

    void Update()
    {

        float posicion_Y = transform.position.y;
        float distanciaAlJugador = Vector3.Distance(transform.position, objetivo.position);
        float distanciaAlInicio = Vector3.Distance(transform.position, posicionInicial);

        // Si está dentro del rango del jugador, mover hacia él
        if (distanciaAlJugador <= rango && distanciaAlJugador > distanciaMinima)
        {
            regresando = false;

            // Detectar si hay una pared frente al enemigo
            bool paredEnfrente = DetectarPared();

            Vector3 direccion = (objetivo.position - transform.position).normalized;
            Vector3 nuevaPos = transform.position + direccion * velocidad * Time.deltaTime;
            nuevaPos.y = posicion_Y;

            // Solo mover si no hay pared enfrente
            if (!paredEnfrente)
            {
                transform.position = nuevaPos;
            }

            // Rotar hacia el objetivo
            RotarHaciaObjetivo();
        }

        // Si no está en rango y no está en su posición inicial, regresar
        else if (distanciaAlJugador > rango && distanciaAlInicio > umbralLlegada)
        {
            regresando = true;

            Vector3 direccion = (posicionInicial - transform.position).normalized;
            Vector3 nuevaPos = transform.position + direccion * velocidad * Time.deltaTime;
            nuevaPos.y = posicion_Y;

            transform.position = nuevaPos;

            // Rotar hacia la posición inicial
            RotarHaciaPosicionInicial();
        }
        else
        {
            // Ya está en la posición inicial
            regresando = false;
        }
    }

    bool DetectarPared()
    {
        // Raycast en la dirección en frente del enemigo
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // chequeo pared
        if (Physics.Raycast(ray, out hit, distanciaDeteccion))
        {
            if (hit.collider.CompareTag(paredTag))
            {
                return true;
            }
        }

        return false;
    }

    void RotarHaciaObjetivo()
    {
        Vector3 direccion = objetivo.position - transform.position;
        direccion.y = 0;

        if (direccion != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo,
                velocidadRotacion * Time.deltaTime);
        }
    }

    void RotarHaciaPosicionInicial()
    {
        Vector3 direccion = posicionInicial - transform.position;
        direccion.y = 0;

        if (direccion != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo,
                velocidadRotacion * Time.deltaTime);
        }
    }
}