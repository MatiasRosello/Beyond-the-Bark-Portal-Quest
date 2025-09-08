using UnityEngine;
using UnityEngine.Events;

public class FirstTutorialTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerEnterWithPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnTriggerEnterWithPlayer?.Invoke();
        }
    }
}
