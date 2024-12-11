using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
}
