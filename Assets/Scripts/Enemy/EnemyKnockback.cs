using UnityEngine;
using System.Collections;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 10f; 
    [SerializeField] private float upwardForce = 6f;
    [SerializeField] private float stunDuration = 0.3f;

    private Rigidbody rb;
    private bool isKnockback = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.freezeRotation = true;

            rb.mass = 1f;
        }
    }

    public void ApplyKnockback(Vector3 direction)
    {
        if (!isKnockback && rb != null)
        {
            StartCoroutine(KnockbackCoroutine(direction));
        }
    }

    private IEnumerator KnockbackCoroutine(Vector3 direction)
    {
        isKnockback = true;

        // Verticalmente
        Vector3 knockbackDirection = new Vector3(direction.x, 0, direction.z).normalized;

        // Horizontalmente
        Vector3 totalForce = (knockbackDirection * knockbackForce) + (Vector3.up * upwardForce);
        rb.AddForce(totalForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(stunDuration);

        // Frenos
        rb.linearVelocity *= 0.3f;

        isKnockback = false;
    }
}