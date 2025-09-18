using ithappy.Animals_FREE;
using UnityEngine;
using UnityEngine.Events;

public class DogTutorialController : MonoBehaviour
{
    public UnityEvent OnReachedPortal;

    [SerializeField] private Transform portalTransform;
    [SerializeField] private float stopDistance = 0.05f;
    [SerializeField] private bool destroyOnReach = true;
    [SerializeField] private CreatureMover mover;
    [SerializeField] private MovePlayerInput playerInput;

    private bool isAutoMoving;
    private Transform currentTarget;
    private bool runWhileMoving;

    private void Update()
    {
        if (!isAutoMoving || currentTarget == null || mover == null) return;

        Vector3 selfPos = transform.position;
        Vector3 destPos = currentTarget.position;
        Vector3 flatDelta = new Vector3(destPos.x - selfPos.x, 0f, destPos.z - selfPos.z);

        if (flatDelta.sqrMagnitude > stopDistance * stopDistance)
        {
            Vector2 axis = new Vector2(0f, 1f);
            mover.SetInput(in axis, in destPos, in runWhileMoving, false);
        }
    }

    public void MoveTo(Transform target, float customStopDistance = -1f, bool run = true)
    {
        currentTarget = target;
        if (customStopDistance > 0f) stopDistance = customStopDistance;
        runWhileMoving = run;
        isAutoMoving = true;
        if (playerInput != null) playerInput.enabled = false;
    }

    public void StartMovingToPortal()
    {
        if (portalTransform == null) return;
        MoveTo(portalTransform, stopDistance, true);
    }

    public void CancelAutoMove()
    {
        isAutoMoving = false;
        if (playerInput != null) playerInput.enabled = true;
    }
}
