using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AnimatorStateInfo animInfoState;
    [SerializeField] private AudioSource stepEnemy;
    [SerializeField] private AudioSource shootBlast;
    [SerializeField] private GameObject blastFire;

    private Vector2 blastVector;
    private Quaternion blastRotation;

    private float velocity = 1f;
    private float direction = 1f;
    private float shift;
    private bool isAttack = false;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Action();
        UpdateSpriteRenderer();
        UpdateAnimation();
        Movement();
        rigidbody.velocity = new Vector2(direction * velocity, rigidbody.velocity.y);
    }

    private void Action()
    { 

        if (!isAttack)
        {
            isAttack = true;
            Invoke("Attack", 4f);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tilemap"))
        {
            direction = direction * -1f;
        }
    }

    private void Movement()
    {
        if (!IsAttackPlay())
        {
            
            velocity = 1f;
            if (!spriteRenderer.flipX)
            {
                direction = 1f;
            }
            else
            {
                direction = -1f;
            }
        } else
        {
            stepEnemy.Play();
            velocity = 0;//0.00001f;
        } 
    }

    private void UpdateAnimation()
    {
        if (velocity != 0.00001f)
        {
            animator.SetBool("attackEnemy", false);
        }
    }

    private void Attack()
    {
        animator.SetBool("attackEnemy", true);
        Invoke("Blast", 1f);
        isAttack = false;
    }

    private void Blast()
    {
        shootBlast.Play();
        if (direction > 0)
        {
            blastRotation = new Quaternion();
        } else
        {
            blastRotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
        }
        
        blastVector = new Vector2(transform.position.x + shift, transform.position.y - 0.6f);
        Instantiate(blastFire, blastVector, blastRotation);
    }

    private void UpdateSpriteRenderer()
    {
        if (direction > 0)
        {
            shift = 0.2f;
            spriteRenderer.flipX = false;
        }
        else if (direction < 0)
        {
            shift = -0.2f;
            spriteRenderer.flipX = true;
        }
    }

    private bool IsAttackPlay()
    {
        animInfoState = animator.GetCurrentAnimatorStateInfo(0);
        if (animInfoState.IsName("AttackEnemy"))
        {
            return true;
        } else
        {
            return false;
        }
    }

    private void OnBecameInvisible()
    {
        stepEnemy.Stop();
        shootBlast.Stop();
    }

}
