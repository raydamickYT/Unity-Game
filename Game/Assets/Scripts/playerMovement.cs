using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    float Horizontal;
    [SerializeField] float jumpingPower;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator PlayerAnimator;
    [SerializeField] private Animator JasAnimator;
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundlayer;


    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal"); //walk var
        //animaties voor het lopen
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(Horizontal));
        JasAnimator.SetFloat("JasSpeed", Mathf.Abs(Horizontal));

        Flip();
    }

    private void FixedUpdate()
    {
        // laat het character bewegen
        rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }

    private void Flip()
    {
        if (isFacingRight && Horizontal < 0f || !isFacingRight && Horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
