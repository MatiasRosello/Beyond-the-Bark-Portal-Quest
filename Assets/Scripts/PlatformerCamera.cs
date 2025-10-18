using UnityEngine;

public class PlatformerCamera : MonoBehaviour
{
    [SerializeField] private GameObject virtualCamera;

    private void Start()
    {
        virtualCamera.SetActive(false);
    }

    private void Update()
    {
        if (virtualCamera.activeInHierarchy)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 playerPosition = player.transform.position;
            Vector3 virtualCameraPosition = virtualCamera.transform.position;

            virtualCameraPosition.z = playerPosition.z;
            virtualCamera.transform.position = virtualCameraPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            virtualCamera.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            virtualCamera.SetActive(false);
        }
    }
}
