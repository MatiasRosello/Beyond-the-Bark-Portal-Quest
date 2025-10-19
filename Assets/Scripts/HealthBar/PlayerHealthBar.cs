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
    private CheckPoints checkPoints;
    private int lives = 3;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
        checkPoints = FindAnyObjectByType<CheckPoints>();
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

            healthBar.ResetHealth();

            if (checkPoints != null)
            {
                if (checkPoints.LastCheckPoint != null)
                {
                    baseObject.transform.position = checkPoints.LastCheckPoint.position;
                }
                else
                {
                    baseObject.transform.position = initialPosition;
                }
            }

            Invoke(nameof(MovementDelay), 0.5f);
        }

        OnLivesDecreased?.Invoke(lives);
    }

    private void MovementDelay()
    {
        thirdPersonController.enabled = true;
    }
}