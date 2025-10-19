using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPoints checkPoints;

    private void Awake()
    {
        checkPoints = FindFirstObjectByType<CheckPoints>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkPoints.UpdateLastCheckPoint(this.transform);
        }
    }
}
