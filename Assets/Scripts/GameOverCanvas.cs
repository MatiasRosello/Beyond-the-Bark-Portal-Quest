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
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
