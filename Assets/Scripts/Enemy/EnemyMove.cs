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
    [SerializeField] private float umbralLlegada = 0.1f;

    private Vector3 posicionInicial;
    private bool regresando = false;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float posicion_Y = transform.position.y;
        float distanciaAlJugador = Vector3.Distance(transform.position, objetivo.position);
        float distanciaAlInicio = Vector3.Distance(transform.position, posicionInicial);

        bool isMoving = false;

        if (distanciaAlJugador <= rango && distanciaAlJugador > distanciaMinima)
        {
            regresando = false;
            bool paredEnfrente = DetectarPared();

            Vector3 direccion = (objetivo.position - transform.position).normalized;
            Vector3 nuevaPos = transform.position + direccion * velocidad * Time.deltaTime;
            nuevaPos.y = posicion_Y;

            if (!paredEnfrente)
            {
                transform.position = nuevaPos;
                isMoving = true;
            }

            RotarHaciaObjetivo();
        }
        else if (distanciaAlJugador > rango && distanciaAlInicio > umbralLlegada)
        {
            regresando = true;

            Vector3 direccion = (posicionInicial - transform.position).normalized;
            Vector3 nuevaPos = transform.position + direccion * velocidad * Time.deltaTime;
            nuevaPos.y = posicion_Y;

            transform.position = nuevaPos;
            isMoving = true;

            RotarHaciaPosicionInicial();
        }
        else
        {
            regresando = false;
        }

        animator.SetFloat("Speed", isMoving ? velocidad : 0f);
    }

    bool DetectarPared()
    {
        // Raycast en la direcci�n en frente del enemigo
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
