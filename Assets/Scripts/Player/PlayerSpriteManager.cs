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
    public bool isFirePlayer = false;

    private PlayerController _playerController;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        _playerController = GetComponentInParent<PlayerController>();
        isFirePlayer = _playerController.isFlyCharecter;
    }

    private void Update()
    {
        if (isFirePlayer)
        {
            anim.SetFloat("Horizontal", rb.velocity.x);
            anim.SetFloat("Vertical", rb.velocity.y);
        }
        
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
