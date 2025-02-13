using UnityEngine;

public class EnemyAttack : EnemyFunction
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _cooldown = 2f;
    [SerializeField] private float _timer = 0;
    [SerializeField] private GameObject damageNumberText;
    private bool _attackable = false;



    void Start()
    {
        _collider = GetComponent<Collider2D>();
        InitializeEnemy();
    }
    // Update is called once per frame
    void Update()
    {
        if (_attackable)
        {
            _timer += Time.deltaTime;
            if (_timer >= _cooldown)
            {
                _timer = 0;
                _attackable = false;
            }
        }
        CheckHealth();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.PLAYER)
             && _attackable == false)
        {
            Attack();
        }
    }
    private void TakeDamage()
    {
        enemy.Health -= StringConstant.PlayerDetail.DAMAGE;
    }
    private void Attack()
    {
        if (!_attackable)
        {
            _attackable = true;
            GameManager.Instance.UpdateHealth(enemy.Damage);
            if (GameManager.Instance.PlayerAttack)
            {
                TakeDamage();
                //GameManager.Instance.ShowDamageNumber(damageNumberText, this.transform.position, StringConstant.PlayerDetail.DAMAGE);
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
