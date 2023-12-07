using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D standingCollider;
    [SerializeField] private BoxCollider2D crouchingCollider;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling, crouching }
    private bool isCrouching = false;

    [SerializeField] private AudioSource jumpSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        //coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }

        if (Input.GetButtonDown("Crouch") && isGrounded())
        {
            isCrouching = true;
            standingCollider.enabled = false;
            crouchingCollider.enabled = true;
        }
        else if (Input.GetButtonUp("Crouch") || !isGrounded())
        {
            isCrouching = false;
            standingCollider.enabled = true;
            crouchingCollider.enabled = false;
        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;      
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;      
        }
        else if (isCrouching)
        {
            state = MovementState.crouching;
        }
        
        else
        { 
            state = MovementState.idle;           
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        BoxCollider2D activeCollider = standingCollider.enabled ? standingCollider : crouchingCollider;
        return Physics2D.BoxCast(activeCollider.bounds.center, activeCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
