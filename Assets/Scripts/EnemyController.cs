using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigi;
    [SerializeField] private Collider2D cld;


    public float health;
    public float damage;

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
        if (other.gameObject.CompareTag(StringConstant.ObjectTags.PLAYER))
        {
            GameManager.Instance.UpdateHealth(this.damage);
        }
    }
}
