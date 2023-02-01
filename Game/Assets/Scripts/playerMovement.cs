using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private float ColorCounter;
    float horizontal;
    [SerializeField] float jumpingPower;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public GameObject Player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundlayer;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        // hoe langer je de Jump knop in gedrukt houdt hoe hoger je komt.
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        // laat het character bewegen
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        print(ColorCounter);
    }

    private bool IsGrounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var NPC = other.GetComponent<ItemPickup>();
        ColorCounter = NPC.ColorCounter;
    }
}
