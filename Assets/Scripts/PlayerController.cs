using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed=5;
    [SerializeField] private float jump=20;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Animator anim;
    private SpriteRenderer sr;
    private bool isRight = true;
    private float horizontal;
    private bool isJump;
    private bool canJump;
    public static Vector2 checkPointPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        checkPointPos=transform.position;
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anim.SetFloat("speedX", Mathf.Abs(horizontal));
        Flip(horizontal);
    }

    void Update()
    {
        var trigerredCollider = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        isJump = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space);
        canJump = trigerredCollider != null;

        if (isJump && canJump)
        {
            Jump();
        }
        anim.SetBool("isGround", canJump);
    }

    void Jump()
    {

        if (isJump)
        {
            rb.AddForce(Vector2.up*jump);
        }
        
    }

    void Flip(float move)
    {
        if (move<0 && isRight)
        {
            isRight = false;
            sr.flipX = true;
        }
        else if (move>0&&!isRight)
        {
            isRight = true;
            sr.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("MovedPlatform"))
        {
            speed = 10;
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("MovedPlatform"))
        {
            speed = 5;
            this.transform.parent = null;
        }
    }

}
