using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigi;
    [SerializeField] private Collider2D cld;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource hitEffect;


    [SerializeField] private Vector3 startPos;
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        cld = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPos = this.transform.position;
        hitEffect = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        AutoMove();
        if (_health <= 0)
        {
            GameManager.Instance.HealthRegen();
            GameManager.Instance.UpdateScore(20);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.PLAYER))
        {
            GameManager.Instance.UpdateHealth(this._damage);
            if (GameManager.Instance.PlayerAttack == true)
            {
                TakeDamage();
                hitEffect.PlayOneShot(hitEffect.clip);
            }
        }
    }
    private void AutoMove()
    {
        if (this.transform.position.x >= startPos.x + 2f)
        {
            MoveLeft();
        }
        else if (this.transform.position.x <= startPos.x - 2f)
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
        rigi.linearVelocity += new Vector2(_speed, 0) * Time.deltaTime;
        spriteRenderer.flipX = true;
    }
    private void MoveLeft()
    {
        rigi.linearVelocity -= new Vector2(_speed, 0) * Time.deltaTime;
        spriteRenderer.flipX = false;
    }
    private void TakeDamage()
    {
        _health -= StringConstant.PlayerDetail.DAMAGE;
    }
}
