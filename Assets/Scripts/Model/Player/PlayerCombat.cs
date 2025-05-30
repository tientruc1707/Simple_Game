using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int direction;
    public bool IsAttacking { get; private set; } = false;
    public Vector3 pos;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (spriteRenderer.flipX)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }
    private void Attack()
    {
        animator.SetTrigger("Attack");
        SoundManager.Instance.PlaySoundEffect(StringConstant.SOUNDS.SWORD);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.DEADZONE))
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                GameManager.Instance.FailLevel();
            }
        }
    }
    public void DealDamage()
    {
        pos = transform.position + spriteRenderer.sprite.bounds.extents * direction / 2f;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(pos, 0.5f);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag(StringConstant.ObjectTags.ENEMY))
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(StringConstant.PlayerDetail.DAMAGE, GetComponent<PlayerHealth>());
                }
            }
        }

    }
}
