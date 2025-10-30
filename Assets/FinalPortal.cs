using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class FinalPortal : MonoBehaviour
{

    [SerializeField] private string nextSceneName;
    [SerializeField] private PortalSoundController soundController;

    private void OnTriggerEnter(Collider other)
    {

        GameObject otherObject = other.gameObject;


        if (otherObject.CompareTag("Player"))
        {
           
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            
            if (enemies.Length == 0)
            {

                if (soundController != null)
                {
                    soundController.EnterPortalSound();
                }

                ThirdPersonController thirdPersonController = otherObject.GetComponent<ThirdPersonController>();
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
            else
            {
                
                Debug.Log("El boss está vivo, eliminalo para avanzar");
            }
        }
    }
}

