using UnityEngine;

public class LivesCanvas : MonoBehaviour
{
    [SerializeField] private GameObject[] lifeGameObjects;

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
        foreach (GameObject life in lifeGameObjects)
        {
            life.SetActive(false);
        }

        for (int i = 0; i < lives; i++)
        {
            lifeGameObjects[i].SetActive(true);
        }
    }
}
