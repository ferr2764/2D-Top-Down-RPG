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
        AreaExit.GotItem = true;
    }
}
