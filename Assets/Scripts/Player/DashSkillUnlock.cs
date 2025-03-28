using UnityEngine;
using System.Collections;

public class DashSkillUnlock : MonoBehaviour
{
    [SerializeField] private GameObject notificationUI; // UI thông báo khi nhặt vật phẩm
    [SerializeField] private TMPro.TextMeshProUGUI notificationText; // Text hiển thị thông báo
    [SerializeField] private AudioClip pickupSound; // Âm thanh khi nhặt

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"🎯 OnTriggerEnter2D gọi với: {collision.gameObject.name}"); // Kiểm tra xem sự kiện có chạy không

        if (collision.CompareTag("Player"))
        {
            Debug.Log("📌 Player nhặt vật phẩm Dash");

            // Kích hoạt kỹ năng Dash
            PlayerController.Instance.EnableDash();
            Debug.Log("✅ EnableDash đã chạy xong");

            // Hiển thị thông báo
            if (notificationUI != null && notificationText != null)
            {
                Debug.Log("🔔 Hiển thị UI thông báo");
                notificationUI.SetActive(true);
                notificationText.text = "Bạn đã được nâng cấp kĩ năng Dash!\nVui lòng bấm Space để dashing!";
                StartCoroutine(HideNotificationAfterDelay(2f));
            }

            // Phát âm thanh
            if (pickupSound != null)
            {
                Debug.Log("🔊 Phát âm thanh nhặt vật phẩm");
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            // Xóa vật phẩm ngay lập tức
            Debug.Log("🗑️ Xóa vật phẩm ngay");
            Destroy(gameObject);
        }
    }

    private IEnumerator HideNotificationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (notificationUI != null)
        {
            Debug.Log("❌ Ẩn UI thông báo");
            notificationUI.SetActive(false);
        }
    }
}
