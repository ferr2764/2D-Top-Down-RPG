using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayFromStart()
    {
        SceneManager.LoadSceneAsync("Forest");
    }
    public void ToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
