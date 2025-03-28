using UnityEngine;
using UnityEngine.UI;

public class DashSkillUnlock : MonoBehaviour
{
    [SerializeField] private GameObject notificationUI; // UI thông báo khi nhặt vật phẩm
    [SerializeField] private AudioClip pickupSound; // Âm thanh khi nhặt

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Kiểm tra nếu người chơi nhặt vật phẩm
        {
            PlayerController.Instance.EnableDash(); // Mở khóa Dash

            // Hiển thị UI thông báo
            if (notificationUI != null)
            {
                notificationUI.SetActive(true); // 👉 BẬT UI
                Invoke("HideNotification", 2f); // Ẩn sau 2 giây
            }

            // Phát âm thanh khi nhặt vật phẩm
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            Destroy(gameObject); // Xóa vật phẩm sau khi nhặt
        }
    }

    private void HideNotification()
    {
        if (notificationUI != null)
        {
            notificationUI.SetActive(false); // 👉 TẮT UI sau 2 giây
        }
    }
}
