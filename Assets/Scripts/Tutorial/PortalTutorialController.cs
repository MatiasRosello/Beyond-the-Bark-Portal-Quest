using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTutorialController : MonoBehaviour
{
    [SerializeField] private GameIconContainer gameIconContainer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();
            thirdPersonController.GetComponent<Animator>().SetFloat("Speed", 0);
            thirdPersonController.enabled = false;

            if (gameIconContainer != null)
            {
                gameIconContainer.Tween();
            }
            // Load in next level
            // else
            // {
            //     SceneTransitionManager.Instance.FadeIn(
            //         null,
            //         () => SceneManager.LoadScene("Level1"),
            //         null
            //     );
            // }
        }
    }
}
