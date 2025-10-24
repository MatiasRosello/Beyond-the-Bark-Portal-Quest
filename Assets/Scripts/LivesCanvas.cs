using UnityEngine;
using UnityEngine.UI;

public class LivesCanvas : MonoBehaviour
{
    [SerializeField] private Image[] lifeImages;

    private PlayerHealthBar playerHealthBar;

    private void Awake()
    {
        playerHealthBar = FindAnyObjectByType<PlayerHealthBar>();
    }

    private void OnEnable()
    {
        playerHealthBar.OnLivesDecreased.AddListener(PlayerHealthBar_OnLivesDecreased);
    }

    private void OnDisable()
    {
        playerHealthBar.OnLivesDecreased.RemoveListener(PlayerHealthBar_OnLivesDecreased);
    }

    private void PlayerHealthBar_OnLivesDecreased(int lives)
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            Color color = lifeImages[i].color;
            color.a = (i < lives) ? 1f : 0.1f; // Cambiar transparencia
            lifeImages[i].color = color;
        }
    }
}
