using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTutorialController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();
            thirdPersonController.enabled = false;

            SceneTransitionManager.Instance.FadeIn(
                null,
                () => SceneManager.LoadScene("Level1"),
                null);
        }
    }
}
