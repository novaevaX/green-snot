using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{

    private bool isEntered = false;
    [SerializeField] GameObject blockElement;
    [SerializeField] float timeCreateElement = 1f;
    [SerializeField] GameObject waypoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isEntered)
        {
            isEntered = true;
            Invoke("CreateBlockElement", timeCreateElement);
        }
    }

    private void CreateBlockElement()
    {
        Instantiate(blockElement, new Vector2(transform.position.x + waypoint.transform.localPosition.x, transform.position.y + waypoint.transform.localPosition.y), transform.rotation);
    }
}
