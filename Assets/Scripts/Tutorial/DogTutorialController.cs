using UnityEngine;
using UnityEngine.Events;

public class DogTutorialController : MonoBehaviour
{
    public UnityEvent OnReachedPortal;

    [SerializeField] private Transform portalTransform;

    private float rotateSpeed = 12f;
    private float moveSpeed = 3f;
    private float stopDistance = 0.05f; // Distancia mínima al portal

    private bool shouldRotateToPortal;
    private bool shouldMoveToPortal;

    private void Update()
    {
        if (portalTransform == null) return;

        if (shouldRotateToPortal)
        {
            // Vector hacia el portal
            Vector3 toTarget = new Vector3(portalTransform.position.x - transform.position.x, 0f, portalTransform.position.z - transform.position.z);

            if (toTarget.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(toTarget);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

                // Cuando está suficientemente alineado, cambia a fase de movimiento
                if (Quaternion.Angle(transform.rotation, targetRotation) < 2f)
                {
                    shouldRotateToPortal = false;
                    shouldMoveToPortal = true;
                }
            }
        }
        else if (shouldMoveToPortal)
        {
            Vector3 targetPos = new Vector3(portalTransform.position.x, transform.position.y, portalTransform.position.z);

            // Mover hacia el portal
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            // Si llegó cerca del portal
            if (Vector3.Distance(transform.position, targetPos) <= stopDistance)
            {
                shouldMoveToPortal = false;
                OnReachedPortal?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    public void StartMovingToPortal()
    {
        shouldRotateToPortal = true;
        shouldMoveToPortal = false;
    }
}