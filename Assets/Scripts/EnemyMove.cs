using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private float rango = 5f;
    [SerializeField] private float distanciaMinima = 2f;
    [SerializeField] private float velocidad = 3f;
    [SerializeField] private float velocidadRotacion = 5f;
    [SerializeField] private string paredTag = "Pared"; // raycast
    [SerializeField] private float umbralLlegada = 0.1f; 

    private Rigidbody rb;
    private bool paredDetectada;
    private Vector3 ultimaDireccion;
    private bool mover = true;
    private bool corutinaActiva = false;
    private Vector3 posicionInicial;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        posicionInicial = transform.position;
    }

    void FixedUpdate()
    {
        if (!mover) return; // si se bloquea el movimiento

        float posicion_Y = transform.position.y;
        Vector3 destino;

        float distanciaJugador = Vector3.Distance(transform.position, objetivo.position);

        if (distanciaJugador <= rango)
        {
            destino = objetivo.position; // si esta cerca del player
        }
        else
        {
            destino = posicionInicial;
        }

        // comprobar si volvio a la posicion inicial
        if (Vector3.Distance(transform.position, destino) < umbralLlegada)
        {
            return;
        }

        Vector3 direccion = (destino - transform.position).normalized;
        direccion.y = 0;
        float distanciaMovimiento = velocidad * Time.fixedDeltaTime;
        Vector3 origenRaycast = transform.position + Vector3.up * 1f;

        ultimaDireccion = direccion;

        // Raycast para detectar paredes
        if (Physics.Raycast(origenRaycast, direccion, out RaycastHit hit, distanciaMovimiento + 0.5f))
        {
            Debug.Log("Raycast tocó: " + hit.collider.name + " | Tag: " + hit.collider.tag);

            if (hit.collider.CompareTag(paredTag))
            {
                paredDetectada = true;

                if (!corutinaActiva)
                    StartCoroutine(PausarMovimiento(2f));

                return;
            }
        }

        paredDetectada = false;

        // mover hacia destino solo si está lejos
        Vector3 nuevaPos = transform.position + direccion * distanciaMovimiento;
        nuevaPos.y = posicion_Y;
        rb.MovePosition(nuevaPos);

        // miramos hacia el player
        RotarHaciaObjetivo(direccion);
    }

    void RotarHaciaObjetivo(Vector3 direccion)
    {
        if (direccion != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotacionObjetivo,
                velocidadRotacion * Time.fixedDeltaTime));
        }
    }

    IEnumerator PausarMovimiento(float tiempo)
    {
        mover = false;
        corutinaActiva = true;
        yield return new WaitForSeconds(tiempo);
        mover = true;
        corutinaActiva = false;
    }
}
