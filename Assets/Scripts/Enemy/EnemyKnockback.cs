using UnityEngine;
using System.Collections;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 12f; 
    [SerializeField] private float knockbackDuration = 0.1f;
    [SerializeField]
    private AnimationCurve knockbackCurve = new AnimationCurve(
        new Keyframe(0, 0),
        new Keyframe(0.2f, 1), // rapidez de knockback
        new Keyframe(1, 0)
    );

    private Rigidbody rb;
    private bool isKnockback = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + (new Vector3(direction.x, 0, direction.z).normalized * knockbackForce);

        float elapsedTime = 0f;

        while (elapsedTime < knockbackDuration)
        {
            float curveValue = knockbackCurve.Evaluate(elapsedTime / knockbackDuration);
            Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, curveValue);
            rb.MovePosition(newPosition);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        rb.MovePosition(targetPosition);
        isKnockback = false;
    }
}