using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PortalLevel1Controller : MonoBehaviour
{
    // El nombre de la siguiente escena. Lo configuras en Unity.
    [SerializeField] private string nextSceneName;
    [SerializeField] private PortalSoundController soundController;

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que colisiona es el jugador
        if (other.gameObject.CompareTag("Player"))
        {

            if (soundController != null)
            {
                soundController.EnterPortalSound();
            }
            // Detén el movimiento y las animaciones del jugador
            ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();
            if (thirdPersonController != null)
            {
                thirdPersonController.GetComponent<Animator>().SetFloat("Speed", 0);
                thirdPersonController.enabled = false;
            }

            // Inicia la transición de escena usando SceneTransitionManager
            SceneTransitionManager.Instance.FadeIn(
                null,
                () => SceneManager.LoadScene(nextSceneName),
                null);
        }
    }
}
