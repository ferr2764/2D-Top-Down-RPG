using UnityEngine;

public class AttackingPlayer : MonoBehaviour
{
    public float attackRange = 2f;
    public float detectionRange = 5f;
    public float attackCooldown = 1.5f;
    public float lastAttackTime;

    private Animator animator;
    private Transform player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance < attackRange && Time.time > lastAttackTime + attackCooldown) 
            {
                animator.SetBool("isAttacking", true);
                lastAttackTime = Time.time;
            }
            else if (distance > attackRange && distance <= detectionRange)
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }
}
