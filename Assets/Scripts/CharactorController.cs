using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    public static CharactorController Instance { get; private set; }
    [SerializeField] private Rigidbody2D rigi;
    [SerializeField] private Collider2D cld;
    [SerializeField] private SpriteRenderer sprite;


    public float moveForce = 60f;
    public float jumpForce = 270f;
    bool jump = false;
    [SerializeField] private Transform Camera;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        cld = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            jump = true;
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
    }
    private void Jump()
    {
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
        int layerMask = LayerMask.GetMask("Ground");
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
}
