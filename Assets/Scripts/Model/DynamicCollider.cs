using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
public class DynamicCollider : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        DynamicBox();
    }
    private void DynamicBox()
    {
        if (spriteRenderer != null && boxCollider != null)
        {
            transform.position = GetComponent<Rigidbody2D>().position;
            Vector2 sprtieSize = spriteRenderer.sprite.bounds.size;
            boxCollider.size = sprtieSize;
            boxCollider.offset = new Vector2(0, sprtieSize.y / 2f);
        }
    }
}
