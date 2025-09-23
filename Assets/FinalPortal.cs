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
            // Busca todos los GameObjects con el tag "Enemy" en la escena
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Si no hay enemigos (la longitud del array es 0), procede con la lógica del portal
            if (enemies.Length == 0)
            {
                // La lógica de la escena anterior y el personaje se ejecutan solo si NO hay enemigos
                ThirdPersonController thirdPersonController = otherObject.GetComponent<ThirdPersonController>();
                if (thirdPersonController != null)
                {
                    thirdPersonController.GetComponent<Animator>().SetFloat("Speed", 0);
                    thirdPersonController.enabled = false;
                }

                // Inicia la transición a la siguiente escena
                SceneTransitionManager.Instance.FadeIn(
                    null,
                    () => SceneManager.LoadScene(nextSceneName),
                    null);
            }
            else
            {
                // Si hay enemigos, el personaje NO se detiene y se muestra un mensaje de debug
                Debug.Log("El boss está vivo, eliminalo para avanzar");
            }
        }
    }
}

