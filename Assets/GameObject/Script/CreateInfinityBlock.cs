using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInfinityBlock : MonoBehaviour
{
    private bool isEntered = false;
    private bool createPlatform = true;
    private bool isStart = false;
    [SerializeField] GameObject blockElement;
    [SerializeField] float timeCreateElement = 2f;
    [SerializeField] float timer = 0f;
    [SerializeField] GameObject waypoint;

    private void FixedUpdate()
    {
        StartOfCreate();
        if (isEntered)
        {
            if (createPlatform)
            {
                createPlatform = false;
                Invoke("CreateBlockElement", timeCreateElement);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isStart = true;
    }

    private void CreateBlockElement()
    {
        createPlatform = true;
        Instantiate(blockElement, new Vector2(transform.position.x + waypoint.transform.localPosition.x, transform.position.y + waypoint.transform.localPosition.y), transform.rotation);
    }

    private void StartOfCreate()
    {
        if (isStart)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                isEntered = true;
            }
        }
    }

}
