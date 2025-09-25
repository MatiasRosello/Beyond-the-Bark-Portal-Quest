using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}