using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : HealthBar, IDie
{
    public UnityEvent<int> OnLivesDecreased;

    [SerializeField] private ThirdPersonController thirdPersonController;

    private Vector3 initialPosition;
    private CheckPoints checkPoints;
    private int lives = 3;

    protected override void Awake()
    {
        base.Awake();
        checkPoints = FindAnyObjectByType<CheckPoints>();
    }

    protected override void Start()
    {
        base.Start();
        initialPosition = baseGameObject.transform.position;
    }

    public override void Die()
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

            ResetHealth();

            if (checkPoints != null)
            {
                if (checkPoints.LastCheckPoint != null)
                {
                    baseGameObject.transform.position = checkPoints.LastCheckPoint.position;
                }
                else
                {
                    baseGameObject.transform.position = initialPosition;
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