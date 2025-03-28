using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayFromStart()
    {
        UIFade.Instance.ToggleUI(true);
        SceneManager.LoadSceneAsync("Forest");
    }
    public void ToMainMenu()
    {
        UIFade.Instance.ToggleUI(true);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
