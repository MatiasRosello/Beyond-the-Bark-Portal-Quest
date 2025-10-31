using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishedCanvas : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnCreditosButtonPressed()
    {
        SceneManager.LoadScene("CreditosVictory");
    }
    public void OnQuitButtonPressed()
    {
        #if UNITY_EDITOR
           // Si estamos en el editor
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Si estamos en build final
            Application.Quit();
        #endif
    }

    public void OnMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnVictoryPressed()
    {
        SceneManager.LoadScene("GameFinished");
    }
}
