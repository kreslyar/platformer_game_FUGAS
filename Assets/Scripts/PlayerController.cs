using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed=5;
    [SerializeField] private float jump=20;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private bool isRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(move*speed, rb.velocity.y,0);
        anim.SetFloat("speedX", Mathf.Abs(move));
        Flip(move);
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
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
}
