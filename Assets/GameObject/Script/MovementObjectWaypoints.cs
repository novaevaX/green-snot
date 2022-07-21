using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObjectWaypoints : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject[] waypoint;
    [SerializeField] private AudioSource movementAudioEffect;

    private int currentIndexWaypoint = 0;
    [SerializeField]private float speed = 3f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        FlipSpriteRenderer();
    }

    private void MovePlatform()
    {

        if(Vector2.Distance(waypoint[currentIndexWaypoint].transform.position, transform.position) < .1f)
        {
            currentIndexWaypoint++;
            if(currentIndexWaypoint >= waypoint.Length)
            {
                currentIndexWaypoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentIndexWaypoint].transform.position, Time.deltaTime * speed);
    }

    private void FlipSpriteRenderer()
    {
        if(currentIndexWaypoint == 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    private void OnBecameVisible()
    {
        movementAudioEffect.Play();
    }

    private void OnBecameInvisible()
    {
        movementAudioEffect.Stop();
    }
}
