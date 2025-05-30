using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyHealth
{
    private Rigidbody2D _rigidbody;

    private Vector3 startPosition;

    private bool isVulnerable = true;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }
    private void FixedUpdate()
    {
        AutoMove();
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.PLAYER))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (isVulnerable)
            {
                playerHealth.TakeDamage(enemy.Damage);
                StartCoroutine(InvulnerabilityCoroutine(2f));
            }
        }
    }

    IEnumerator InvulnerabilityCoroutine(float duration)
    {
        isVulnerable = false;
        yield return new WaitForSeconds(duration);
        isVulnerable = true;
    }
}