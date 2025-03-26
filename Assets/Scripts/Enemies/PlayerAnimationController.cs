using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;

    public RuntimeAnimatorController walkRight;
    public RuntimeAnimatorController walkLeft;
    public RuntimeAnimatorController walkFront;
    public RuntimeAnimatorController walkBack;

    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Kiểm tra hướng di chuyển và đổi Animator Controller
        if (movement.x > 0)
        {
            animator.runtimeAnimatorController = walkRight;
        }
        else if (movement.x < 0)
        {
            animator.runtimeAnimatorController = walkLeft;
        }
        else if (movement.y > 0)
        {
            animator.runtimeAnimatorController = walkBack;
        }
        else if (movement.y < 0)
        {
            animator.runtimeAnimatorController = walkFront;
        }
    }
}
