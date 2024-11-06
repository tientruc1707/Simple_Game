using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    [SerializeField] private Vector3 startPosition;
    private Enemy enemy;

    [System.Serializable]
    public struct Enemy
    {
        public float Health { get; set; }
        public float Damage { get; set; }
        public float Speed { get; set; }
        public Enemy(float health, float damage, float speed)
        {
            this.Health = health;
            this.Damage = damage;
            this.Speed = speed;
        }
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        startPosition = transform.position;
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        if (gameObject.CompareTag(StringConstant.EnemyType.BOAR))
        {
            enemy = new Enemy(100, 20, 3);
        }
        else if (gameObject.CompareTag(StringConstant.EnemyType.BEE))
        {
            enemy = new Enemy(50, 10, 5);
        }
    }

    private void FixedUpdate()
    {
        AutoMove();
        CheckHealth();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.PLAYER))
        {
            GameManager.Instance.UpdateHealth(enemy.Damage);
            if (GameManager.Instance.PlayerAttack)
            {
                TakeDamage();
            }
        }
    }

    private void AutoMove()
    {
        if (transform.position.x >= startPosition.x + 2f)
        {
            MoveLeft();
        }
        else if (transform.position.x <= startPosition.x - 2f)
        {
            MoveRight();
        }
        else
        {
            if (spriteRenderer.flipX)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }
    }

    private void MoveRight()
    {
        _rigidbody.linearVelocity = new Vector2(enemy.Speed, _rigidbody.linearVelocity.y);
        spriteRenderer.flipX = true;
    }

    private void MoveLeft()
    {
        _rigidbody.linearVelocity = new Vector2(-enemy.Speed, _rigidbody.linearVelocity.y);
        spriteRenderer.flipX = false;
    }

    private void TakeDamage()
    {
        enemy.Health -= StringConstant.PlayerDetail.DAMAGE;
    }

    private void CheckHealth()
    {
        if (enemy.Health <= 0)
        {
            GameManager.Instance.HealthRegen();
            GameManager.Instance.UpdateScore(20);
            Destroy(gameObject);
        }
    }
}