using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
