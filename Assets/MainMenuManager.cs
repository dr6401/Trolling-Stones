using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
