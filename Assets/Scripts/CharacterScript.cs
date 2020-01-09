using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public bool isPaused = false;
    float maxSpeed = 10f;
    bool facingRight = true;
    private Rigidbody2D rb2d;
    private CapsuleCollider2D charCollider;
    private Vector2 charColliderSize;
    private Vector2 charColliderOffset;
    public float jumpForce = 700f;

    Animator anim;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float dashForceMax = 20;
    bool enableJump = true;
    float dashForce = 0;
    float timer = 0.0f;
    float timer2 = 0.0f;
    // Start is called before the first frame update
    void StartDash()
    {
        dashForce = dashForceMax;
        if (!facingRight)
            dashForce *= -1;
        rb2d.gravityScale = 0;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        charCollider.size = new Vector2(0.34f, 0.0001f);
        charCollider.offset = new Vector2(0f, -0.18f);
    }

    void EndDash()
    {
        anim.SetBool("Dash", false);
        anim.SetFloat("Speed", 0);
        dashForce = 0;
        Debug.Log("End");
        rb2d.gravityScale = 4;
        charCollider.size = new Vector2(0.34f, 0.57f);
        charCollider.offset = new Vector2(0f, -0.05f);
        charCollider.size = charColliderSize;
        charCollider.offset = charColliderOffset;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        charCollider = GetComponent<CapsuleCollider2D>();
        charColliderSize = charCollider.size;
        charColliderOffset = charCollider.offset;
    }

    void FixedUpdate()
    {
        if (isPaused)
        {
            StopPlayer();
            return;
        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rb2d.velocity.y);
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));

        if (anim.GetBool("Dash"))
        {
            rb2d.gravityScale = 0;
            rb2d.velocity = new Vector2(dashForce, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();
        }

    }

    void Update()
    {
        if (isPaused)
        {
            StopPlayer();
            return;
        }
        if (grounded && !enableJump)
            enableJump = true;
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.playSound("jump");
            anim.SetBool("Ground", false);
            rb2d.AddForce(new Vector2(0, jumpForce));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && enableJump)
        {
            SoundManager.playSound("slash");
            anim.SetBool("Dash", true);
            enableJump = false;
        }
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (Input.GetKey(KeyCode.Q))
        {
            if (timer > 0.3f) {
                SoundManager.playSound("run");
                timer = 0.0f;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (timer2 > 0.3f) {
                SoundManager.playSound("run");
                timer2 = 0.0f;
            }
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void StopPlayer()
    {
        rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        anim.SetBool("Ground", true);
        anim.SetFloat("Speed", 0f);
    }
}
