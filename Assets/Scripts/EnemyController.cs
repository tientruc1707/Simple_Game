using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigi;
    [SerializeField] private Collider2D cld;


    public float health;
    public float damage;

    void Awake()
    {
        health = 50;
        damage = 10;
    }
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        cld = GetComponent<Collider2D>();
    }

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D other)
    {
    }
}
