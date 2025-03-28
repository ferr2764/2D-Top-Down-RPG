using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, selectLevel;
    public void SelectLevel()
    {
        mainMenu.transform.GetChild(0).gameObject.SetActive(false);
        selectLevel.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void GoToMainMenu()
    {
        mainMenu.transform.GetChild(0).gameObject.SetActive(true);
        selectLevel.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Forest");
    }
}
