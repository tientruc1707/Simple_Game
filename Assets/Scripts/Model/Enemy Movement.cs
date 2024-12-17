using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyFunction
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Vector3 startPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        InitializeEnemy();
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
}