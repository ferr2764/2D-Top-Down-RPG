using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Nhân vật người chơi
    public float speed = 3f;
    public float detectRange = 5f;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveDir;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < detectRange)
        {
            // Tính toán hướng di chuyển
            moveDir = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Cập nhật flip dựa trên hướng di chuyển
            UpdateAnimation();
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
