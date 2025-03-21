using UnityEngine;

public class Grape : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject grapeProjectilePrefab;

    private Animator myAnimator;
    private SpriteRenderer spriteRenderer;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);

        spriteRenderer.flipX = transform.position.x - PlayerController.Instance.transform.position.x < 0 ? false : true;
    }

    public void SpawnProjectileAnimEvent()
    {
        Instantiate(grapeProjectilePrefab, transform.position, Quaternion.identity);
    }
}
