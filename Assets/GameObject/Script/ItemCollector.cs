using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField]private int itemsNeedCollect = 9;

    [SerializeField] private GameObject exitWall;
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private Text pointText;
    [SerializeField] private AudioSource collectionItemAudioEffect;
    private void Update()
    {
        if(itemsNeedCollect == 0)
        {
            Destroy(exitWall);
            Destroy(exitDoor);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            collectionItemAudioEffect.Play();
            Destroy(collision.gameObject);
            itemsNeedCollect--;
            pointText.text = "Need collect : " + itemsNeedCollect;
        }
    }
}
