using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
