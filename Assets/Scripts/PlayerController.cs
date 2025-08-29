using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Cursor centrado
    }

    void Update()
    {
        // Rotación con mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        // Movimiento con WASD o Flechas
        float h = Input.GetAxis("Horizontal"); // A/D o ← →
        float v = Input.GetAxis("Vertical");   // W/S o ↑ ↓
        Vector3 move = transform.forward * v + transform.right * h;
        
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
    }
}
