using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerSpriteManager : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    internal int LocalX = 1;
    public int Direct = 1;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        anim.SetFloat("speed", Math.Abs(rb.velocity.x + rb.velocity.y));
        Flip();
    }
    private void Flip()
    {
        if (rb.velocity.x > 0) LocalX = 1;

        if (rb.velocity.x < 0) LocalX = -1;

        transform.localScale = FlipVector(LocalX);
    }
    private Vector3 FlipVector(int x) => new Vector3(x * Direct, 1, 1);
}
