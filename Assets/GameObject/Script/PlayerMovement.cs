using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private BoxCollider2D boxCollaider;

    private float direction;
    [SerializeField]private float jumpForce = 5f;
    [SerializeField]private float velocity = 5f;
    private bool ground = false;
    
    private enum statePlayer { Idle, Running, Jumping, Falling };

    [SerializeField]private LayerMask layerGround;
    [SerializeField]private LayerMask layerPlatform;
    [SerializeField]private AudioSource plauerJumpSoundEffect;
    [SerializeField]private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxCollaider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Jump();
    }
    private void FixedUpdate()
    {
        HorizontalMovement();
        UpdateSpriteRenderer();
        UpdateAnimation();
    }

    private void HorizontalMovement()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(direction * velocity, rigidBody.velocity.y);
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && IsGround())
        {
            particleSystem.Play();
            plauerJumpSoundEffect.Play();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }

    private void UpdateSpriteRenderer()
    {
        if(direction > 0)
        {
            spriteRenderer.flipX = false;
        } else if(direction < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void UpdateAnimation()
    {

        statePlayer statePlayer;

        if(direction != 0)
        {
            statePlayer = statePlayer.Running;
        }
        else
        {
            statePlayer = statePlayer.Idle;
        }

        if(rigidBody.velocity.y > 0.1f)
        {
            statePlayer = statePlayer.Jumping;
        } else if(rigidBody.velocity.y < -0.1f)
        {
            statePlayer = statePlayer.Falling;
        }

        animator.SetInteger("statePlayer", (int)statePlayer);
    }

    private bool IsGround()
    {
        if(Physics2D.BoxCast(boxCollaider.bounds.center, boxCollaider.bounds.size, 0f, Vector2.down, 0.1f, layerGround))
        {
            ground = true;
        }
        else if (Physics2D.BoxCast(boxCollaider.bounds.center, boxCollaider.bounds.size, 0f, Vector2.down, 0.1f, layerPlatform)){
            ground = true;
        } else
        {
            ground = false;
        }
        return ground;
        //return Physics2D.BoxCast(boxCollaider.bounds.center, boxCollaider.bounds.size, 0f, Vector2.down, 0.1f, layerGround);
    }
}
