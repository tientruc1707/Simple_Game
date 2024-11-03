using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigi;
    [SerializeField] private Collider2D cld;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform Camera;

    public float moveForce = 150f;
    public float jumpForce = 250f;
    bool jump = false;
    bool isOnGround = false;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        cld = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            jump = true;
            isOnGround = false;
        }
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("DealDmg", true);
            GameManager.Instance.PlayerAttack = true;
        }
        else
        {
            anim.SetBool("DealDmg", false);
            GameManager.Instance.PlayerAttack = false;
        }
    }
    void FixedUpdate()
    {
        SetCameraFollow();
        Run();
        Jump();
    }
    void SetCameraFollow()
    {
        Vector3 playerPos = transform.position;
        playerPos.z = -10;
        if (playerPos.x >= 0)
        {
            Camera.position = playerPos;
        }
    }
    private void Run()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        rigi.velocity = new Vector2(moveX * moveForce * Time.deltaTime, rigi.velocity.y > -4.0f ? rigi.velocity.y : -4.0f);
        if (moveX == 1)
        {
            sprite.flipX = false;
        }
        else if (moveX == -1)
        {
            sprite.flipX = true;
        }
        anim.SetFloat("Running", Math.Abs(moveX));
    }
    private void Jump()
    {
        anim.SetBool("Jump", !isOnGround);
        if (OnGround())
        {
            if (jump)
            {
                rigi.velocity = new(rigi.velocity.x, jumpForce * Time.deltaTime);
            }
            jump = false;
        }
    }
    bool OnGround()
    {
        Color colorRay = Color.red;

        float rayLength = 1f;
        Vector2 startPos = (Vector2)transform.position - new Vector2(0, cld.bounds.extents.y);
        Ray ray = new(transform.position, transform.forward);
        int layerMask = LayerMask.GetMask(StringConstant.ObjectTags.GROUND);
        RaycastHit2D hit = Physics2D.Raycast(startPos, Vector2.down, rayLength, layerMask);

        if (hit.collider != null)
        {
            colorRay = Color.green;
        }
        else
        {
            colorRay = Color.red;
        }
        Debug.DrawRay(startPos, Vector2.down * rayLength, colorRay);
        return hit.collider != null;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.GROUND))
        {
            isOnGround = true;
        }
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.TRAP))
        {
            anim.SetBool("Dead", true);
        }
    }
}
