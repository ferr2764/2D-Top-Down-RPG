using TMPro;
using UnityEngine;

public class Map1Ender : MapEnder
{
    public GameObject notificationUI; // UI thông báo khi nhặt vật phẩm
    public TextMeshProUGUI notificationText; // Kéo vào trong Inspector
    public AudioClip pickupSound; // Kéo âm thanh vào đây trong Inspector

    public override void Action()
    {
        PlayerController.Instance.EnableDash(); // Mở khóa Dash

        // ✅ Hiển thị UI thông báo
        if (notificationUI != null)
        {
            notificationUI.SetActive(true);
        }
        else
        {
            Debug.LogError("⚠️ Lỗi: Không tìm thấy NotificationUI!");
        }

        // ✅ Hiển thị văn bản thông báo
        if (notificationText != null)
        {
            notificationText.enabled = true;
            notificationText.text = "Bạn đã được nâng cấp kỹ năng Dash!\nBấm SPACE để Dash!";
        }
        else
        {
            Debug.LogError("⚠️ Lỗi: Không tìm thấy NotificationText!");
        }

        // ✅ Phát âm thanh khi nhặt vật phẩm
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
        else
        {
            Debug.LogError("⚠️ Lỗi: Không tìm thấy âm thanh PickupSound!");
        }

        // ✅ Mở cửa ra exit
        var exit = GameObject.FindWithTag("AreaExit");
        if (exit != null)
        {
            exit.GetComponent<BoxCollider2D>().enabled = true;
            exit.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("⚠️ Lỗi: Không tìm thấy AreaExit!");
        }

        // ✅ Ẩn thông báo sau 2 giây
        Invoke("HideNotification", 2f);
    }

    private void HideNotification()
    {
        if (notificationUI != null)
        {
            notificationUI.SetActive(false); // Ẩn UI thông báo
        }

        if (notificationText != null)
        {
            notificationText.enabled = false; // Ẩn text
        }
    }
}
