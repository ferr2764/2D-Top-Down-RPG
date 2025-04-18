﻿
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Nhân vật người chơi
    public float speed = 3f;
    public float detectRange = 5f;
    public float stopDistance = 0.5f; // Khoảng cách dừng lại gần player
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveDir;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FindPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("PlayerExist");
        if (playerObject != null)
        {
            player = playerObject.transform;
            Debug.Log("🔥 Enemy đã tìm thấy Player!");
        }
        else
        {
            Debug.LogWarning("⚠️ Không tìm thấy Player trong Scene!");
        }
    }

    void Update()
    {
        if (player == null)
        {
            FindPlayer(); // 🔥 Tìm lại Player nếu bị mất khi load Scene
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < detectRange)
        {
            // Tính toán hướng di chuyển
            moveDir = (player.position - transform.position).normalized;

            // Chỉ di chuyển nếu chưa đến gần player
            if (distance > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            // Cập nhật flip dựa trên hướng di chuyển
            UpdateAnimation();
        }
        else
        {
            // Nếu player ngoài vùng phát hiện, reset animation
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
        }
    }

    void UpdateAnimation()
    {
        // Lật sprite nếu di chuyển trái/phải
        if (moveDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Chọn animation theo hướng di chuyển chính
        animator.SetFloat("MoveX", moveDir.x);
        animator.SetFloat("MoveY", moveDir.y);
    }
}