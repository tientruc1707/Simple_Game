using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private float _timeToAttack = 2, _timer = 0;
    private bool _attacking = false;
    [SerializeField] private Vector3 startPosition;
    private Enemy enemy;

    [System.Serializable]
    public struct Enemy
    {
        public float Health { get; set; }
        public float Damage { get; set; }
        public float Speed { get; set; }
        public float Value { get; set; }
        public float AttackRange { get; set; }
        public Enemy(float health, float damage, float speed, float value, float attackRange)
        {
            this.Health = health;
            this.Damage = damage;
            this.Speed = speed;
            this.Value = value;
            this.AttackRange = attackRange;
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
            enemy = new Enemy(100, 20, 3, 30, 2f);
        }
        else if (gameObject.CompareTag(StringConstant.EnemyType.BEE))
        {
            enemy = new Enemy(50, 10, 5, 15, 3f);
        }
    }
    private void Update()
    {
        if (_attacking)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeToAttack)
            {
                _timer = 0;
                _attacking = false;
            }
        }
    }
    private void FixedUpdate()
    {
        AutoMove();
        CheckHealth();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.PLAYER)
             && _attacking == false)
        {
            DealDamage();
        }
    }

    private void AutoMove()
    {
        if (transform.position.x >= startPosition.x + enemy.AttackRange)
        {
            MoveLeft();
        }
        else if (transform.position.x <= startPosition.x - enemy.AttackRange)
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
    private void DealDamage()
    {
        if (!_attacking)
        {
            _attacking = true;
            GameManager.Instance.UpdateHealth(enemy.Damage);
            if (GameManager.Instance.PlayerAttack)
            {
                TakeDamage();
            }
        }
    }
    private void CheckHealth()
    {
        if (enemy.Health <= 0)
        {
            GameManager.Instance.HealthRegen();
            GameManager.Instance.UpdateScore((int)enemy.Value);
            Destroy(gameObject);
        }
    }
}