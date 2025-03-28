using UnityEngine;
using UnityEngine.UI;

public class PickUpLast : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private Text messageText;

    public void ShowVictoryMessage()
    {
        if (GameObject.FindGameObjectsWithTag("Boss").Length <= 1)
        {
            messagePanel.SetActive(true);
            messageText.text = "You have defeated all monsters and saved the world";
        }
    }
}
