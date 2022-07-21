using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBallTrap : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField] float speedBall = 6f;
    [SerializeField] float direction = -1f;
    [SerializeField] float destriyThisObject = 10f;
    [SerializeField] bool isDelete = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidBody.velocity = new Vector2(speedBall * direction, rigidBody.velocity.y);
        Destroy(this.gameObject, destriyThisObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDelete)
        {
            if (collision.gameObject.CompareTag("Tilemap"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
