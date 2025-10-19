using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPoints checkPoints;
    private BoxCollider boxCollider;

    private void Awake()
    {
        checkPoints = FindFirstObjectByType<CheckPoints>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            boxCollider.enabled = false;
            checkPoints.UpdateLastCheckPoint(this.transform);
        }
    }
}
