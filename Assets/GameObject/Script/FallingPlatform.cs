using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] float speedDown = 7f;
    [SerializeField] float timeForFall = 1.5f;
    [SerializeField] bool isMoveDown = false;
    [SerializeField] float movement = 1f;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isMoveDown)
        {
            Movement();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("SpeedPlatform", timeForFall);
        }
        if (collision.gameObject.CompareTag("Tilemap"))
        {
            Destroy(this.gameObject);
        }
    }

    private void SpeedPlatform()
    {
        rigidbody.velocity = new Vector2(0f, speedDown * -1);
    }

    private void Movement()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, movement * -1);
    }
}

