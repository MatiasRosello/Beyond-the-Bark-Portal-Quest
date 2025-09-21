using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthBar : MonoBehaviour, IDie
{
    public UnityEvent<int> OnLivesDecreased;

    [SerializeField] private GameObject baseObject;

    private HealthBar healthBar;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private int lives = 3;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
    }

    private void Start()
    {
        initialPosition = baseObject.transform.position;
        initialRotation = baseObject.transform.rotation;
    }

    public void Die()
    {
        lives -= 1;

        if (lives <= 0)
        {
            print("Game over!");
            Time.timeScale = 0;
        }
        else
        {
            baseObject.transform.position = initialPosition;
            baseObject.transform.rotation = initialRotation;
            healthBar.ResetHealth();
        }

        OnLivesDecreased?.Invoke(lives);
    }
}