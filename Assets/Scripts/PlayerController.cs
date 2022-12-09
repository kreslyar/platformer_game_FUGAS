using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed=5;
    [SerializeField] private float jump=20;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TextMeshProUGUI textPotion;
    [SerializeField] private Lives livesUI;
    [SerializeField] private Transform swordAttack;
    [SerializeField] private LayerMask enemyLayer;

    private Animator anim;
    private SpriteRenderer sr;
    private bool isRight = true;
    private float horizontal;
    private bool isJump;
    private bool canJump;
    public static Vector2 checkPointPos;
    private int potionCount = 0;
    private int lives = 3;
    public int PotionCount
    {
        get => potionCount;
    }

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

        isJump = Input.GetKeyDown(KeyCode.UpArrow);
        canJump = trigerredCollider != null;

        if (isJump && canJump)
        {
            Jump();
        }
        anim.SetBool("isGround", canJump);

        Attack();
    }

    void Jump()
    {
        if (isJump)
        {
            rb.AddForce(Vector2.up*jump);
        }
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("attack");

            var trigerredCollider = Physics2D.OverlapCircle(swordAttack.position, 0.7f, enemyLayer);

            if(trigerredCollider != null)
            {
                Destroy(trigerredCollider.gameObject, 0.3f);
            }
        }
    }

    void Flip(float move)
    {
        if (move<0 && isRight)
        {
            isRight = false;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            //sr.flipX = true;
        }
        else if (move>0&&!isRight)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            isRight = true;
            //sr.flipX = false;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Potion")
        {
            potionCount++;
            textPotion.text = potionCount.ToString();
            GameObject potionObject = collision.gameObject;
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Floor")
        {
            Damage();
        }
    }

    private void Damage()
    {
        lives--;
        livesUI.RemoveLives();
        if (lives == 0)
        {
            Time.timeScale = 0;
            livesUI.GameOver();
        }
    }

}
