using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OnOptionsButtonPressed()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}