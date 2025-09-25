using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : MonoBehaviour, IDie
{
    public UnityEvent<int> OnLivesDecreased;

    [SerializeField] private GameObject baseObject;
    [SerializeField] private ThirdPersonController thirdPersonController;

    private HealthBar healthBar;
    private Vector3 initialPosition;
    private int lives = 3;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
    }

    private void Start()
    {
        initialPosition = baseObject.transform.position;
    }

    public void Die()
    {
        lives -= 1;

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            thirdPersonController.enabled = false;
            thirdPersonController.GetComponent<Animator>().SetFloat("Speed", 0);

            baseObject.transform.position = initialPosition;
            healthBar.ResetHealth();

            Invoke(nameof(MovementDelay), 0.5f);
        }

        OnLivesDecreased?.Invoke(lives);
    }

    private void MovementDelay()
    {
        thirdPersonController.enabled = true;
    }
}