using UnityEngine;
using UnityEngine.Events;

public class DogTutorialController : MonoBehaviour
{
    public UnityEvent OnReachedPortal;

    [SerializeField] private Transform portalTransform;

    private float rotateSpeed = 12f;
    private float moveSpeed = 3f;
    private float stopDistance = 0.05f;
    private bool shouldMoveToPortal;

    private void Update()
    {
        if (!shouldMoveToPortal) { return; }

        transform.position = Vector3.MoveTowards(transform.position, portalTransform.position, moveSpeed * Time.deltaTime);

        Vector3 toTarget = portalTransform.position - transform.position;
        toTarget.y = 0f;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(toTarget), rotateSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, portalTransform.position) <= stopDistance)
        {
            shouldMoveToPortal = false;
            OnReachedPortal?.Invoke();
            Destroy(gameObject);
        }
    }

    public void StartMovingToPortal()
    {
        shouldMoveToPortal = true;
    }
}
