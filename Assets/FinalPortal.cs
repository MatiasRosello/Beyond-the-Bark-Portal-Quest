using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class FinalPortal : MonoBehaviour
{
    
    [SerializeField] private string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        
        GameObject otherObject = other.gameObject;

        
        if (otherObject.CompareTag("Player"))
        {
            
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
        
        else if (otherObject.CompareTag("Enemy"))
        {
            
            GameObject boss = GameObject.FindWithTag("Boss");

            
            if (boss == null)
            {
                
                SceneTransitionManager.Instance.FadeIn(
                    null,
                    () => SceneManager.LoadScene(nextSceneName),
                    null);
            }
        }
    }
}
