using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyType _enemyType;
    protected Enemy enemy;
    protected SpriteRenderer spriteRenderer;
    private int direction;
    void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (_enemyType == EnemyType.BOAR)
        {
            enemy = new Enemy(100, 20, 3, 30, 2f);
        }
        else if (_enemyType == EnemyType.BEE)
        {
            enemy = new Enemy(50, 10, 5, 15, 3f);
        }
    }
    private void Update()
    {
        if (spriteRenderer.flipX)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }
    
    public void TakeDamage(float damage, PlayerHealth health)
    {
        enemy.Health -= damage;
        if (enemy.Health <= 0)
        {
            DataManager.Instance.SetScore( DataManager.Instance.GetScore() + (int)enemy.Value);
            Debug.Log($"Enemy defeated! Score: {DataManager.Instance.GetScore()}");
            health.Heal();
            Destroy(gameObject);
        }
        this.transform.position -= new Vector3(direction * 0.5f, 0, 0);
        StartCoroutine(FreezeMovement(2f));
    }

    IEnumerator FreezeMovement(float duration)
    {
        enemy.Speed = 0;
        yield return new WaitForSecondsRealtime(duration);
        if (_enemyType == EnemyType.BOAR)
        {
            enemy.Speed = 2f;
        }
        else if (_enemyType == EnemyType.BEE)
        {
            enemy.Speed = 3f;
        }
    }
}
