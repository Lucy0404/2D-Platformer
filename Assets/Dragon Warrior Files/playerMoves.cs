using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoves : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 500f;

    private bool grounded;
    private Animator anim;
    private Rigidbody2D rb;
    private float moveInput;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //flip
        if (moveInput > 0.01f)    
            transform.localScale = Vector3.one;
        else if (moveInput < -0.01f)   
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetButtonDown("Jump") && grounded)
            Jump();

        anim.SetBool("isRunning", moveInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce));
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }

    public bool canAttack()
    {
        return moveInput == 0 && grounded;
    }
}
