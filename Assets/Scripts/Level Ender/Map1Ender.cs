using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class Map1Ender : MapEnder
{
    public override void Action()
    {
        PlayerController.Instance.EnableDash(); // Mở khóa Dash
        var canvas = GameObject.FindWithTag("UI");
        canvas.GetComponent<TextMeshProUGUI>().enabled = true;
        Invoke("HideNotification", 2f);
        //AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        //Open exit
        var exit = GameObject.FindWithTag("AreaExit");
        //Enable trigger for the next map
        exit.GetComponent<BoxCollider2D>().enabled = true;
        //Enable portal FX
        exit.transform.GetChild(0).gameObject.SetActive(true);
    }
}
