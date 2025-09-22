using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}