using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PortalNextLevel : MonoBehaviour
{

    private string nextSceneName = "Level2";

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            
            ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();
            if (thirdPersonController != null)
            {
                thirdPersonController.GetComponent<Animator>().SetFloat("Speed", 0);
                thirdPersonController.enabled = false;
            }

            
            SceneTransitionManager.Instance.FadeIn(
                null,
                () => SceneManager.LoadScene(nextSceneName),
                null);
        }
    }
}