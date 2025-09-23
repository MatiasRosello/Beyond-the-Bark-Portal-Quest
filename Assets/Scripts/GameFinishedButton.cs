using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinishedButton : MonoBehaviour
{
    [SerializeField] private Button button;

    public void OnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
