using System.Collections;
using System.IO;
using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{  
    private Rigidbody2D player;
    private BoxCollider2D boxCollider;
    private bool canJump;
    private int groundLayer;
    private int trapLayer;
    private int jumpableLayer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashLength;
    private float dashCooldownOver;
    private Vector2 jumpedFrom;



    private void Awake() 
    {
        player = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        groundLayer = 1 << 8;
        trapLayer = 1 << 9;
        jumpableLayer = groundLayer | trapLayer;
        dashCooldownOver = 0;
    }

    private void Update() 
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, player.velocity.y);

        if (Grounded() && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))) {
           // jumpedFrom = player.transform.position;
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > dashCooldownOver && player.velocity.x != 0) {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.T)) {
            player.transform.position = new Vector2(60, 40);
        }
    }

    private bool Grounded() 
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, jumpableLayer);
        return raycastHit.collider != null;
    }

    private IEnumerator Dash() 
    {
            dashCooldownOver = Time.time + dashCooldown;
            float gravity = player.gravityScale;
            player.gravityScale = 0;
            player.velocity = new Vector2(transform.localScale.x * dashSpeed, 0f);
            yield return new WaitForSeconds(dashLength);
            player.gravityScale = gravity;
    }

    public Vector2 getJumpedFrom() {
        return jumpedFrom;
    }
}

