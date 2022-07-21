using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFire : MonoBehaviour
{
    [SerializeField] private AudioSource flyEffect;
    [SerializeField] private AudioSource explosionEffect;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float moveSpeed = 10f;
    private float direction = 1f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        flyEffect.Play();
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(moveSpeed * direction, rigidbody.velocity.y);
        Invoke("DestroyObject", 3f);
        UpdateSpriteRenderer();
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    private void UpdateSpriteRenderer()
    {
        if (transform.rotation.y == 0)
        {
            direction = 1f;
        }
        else
        {
            direction = -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tilemap"))
        {
            UpdateExplosionAnim();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            UpdateExplosionAnim();
        }
    }

    private void UpdateExplosionAnim()
    {
        explosionEffect.Play();
        moveSpeed = 0f;
        animator.SetBool("Explosion", true);
        Invoke("DestroyObject", 0.3f);
    }

    private void OnBecameInvisible()
    {
        explosionEffect.Stop();
        flyEffect.Stop();
    }


}
