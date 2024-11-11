using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private AudioSource _runSFX, attackSFX;

    private GameManager gameManager;
    public float moveForce = 200f;
    public float jumpForce = 250f;
    public float timeToAttack, timer = 0;
    private bool isJumping = false;
    private bool isOnGround = false;
    private bool _attacking = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            isJumping = true;
            isOnGround = false;
        }
        if (Input.GetMouseButtonDown(1) && !_attacking)
        {
            Attack();
        }
        if (_attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                _attacking = false;
                animator.SetBool("Attack", false);
                timer = 0;
                GameManager.Instance.PlayerAttack = false;
            }
        }
    }

    private void Attack()
    {
        if (!_attacking)
        {
            _attacking = true;
            animator.SetBool("Attack", true);
            attackSFX.Play();
            GameManager.Instance.PlayerAttack = true;
        }
    }
    private void FixedUpdate()
    {
        SetCameraFollow();
        Run();
        Jump();
    }

    private void SetCameraFollow()
    {
        Vector3 playerPosition = transform.position;
        playerPosition.z = -10;
        if (playerPosition.x >= 0)
        {
            cameraTransform.position = playerPosition;
        }
    }

    private void Run()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveForce * Time.deltaTime,
                            rb.linearVelocity.y > -4.0f ? rb.linearVelocity.y : -4.0f);

        if (moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }
        _runSFX.Play();
        animator.SetFloat("Running", Mathf.Abs(moveX));
    }

    private void Jump()
    {
        animator.SetBool("Jump", !isOnGround);

        if (IsOnGround())
        {
            if (isJumping)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * Time.deltaTime);
            }

            isJumping = false;
        }
    }

    private bool IsOnGround()
    {
        Color rayColor = Color.red;

        float rayLength = 1f;
        Vector2 startPosition = (Vector2)transform.position - new Vector2(0, _collider.bounds.extents.y);
        int layerMask = LayerMask.GetMask(StringConstant.ObjectTags.GROUND);
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.down, rayLength, layerMask);

        if (hit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(startPosition, Vector2.down * rayLength, rayColor);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.GROUND))
        {
            isOnGround = true;
        }

        if (other.gameObject.CompareTag(StringConstant.ObjectTags.TRAP))
        {
            animator.SetBool("Dead", true);
            gameManager.UpdateHealth(100);
        }
    }
}
