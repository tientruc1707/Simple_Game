using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
public class DynamicCollider : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;

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
        if (spriteRenderer.sprite)
        {
            //Get Size sprite
            Vector2 sprtieSize = spriteRenderer.sprite.bounds.size;
            //assign to boxcollider
            boxCollider.size = sprtieSize;
            boxCollider.offset = spriteRenderer.sprite.bounds.center;
        }
    }
}
