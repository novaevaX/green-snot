using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterUse : MonoBehaviour
{
    [SerializeField] private AudioSource destrotThisObject;
    [SerializeField] private float timaDestroy = 0.2f;
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            destrotThisObject.Play();
            Invoke("AfterExit", 0.4f);
        }
    }

    private void AfterExit()
    {
        Destroy(this.gameObject);
    }
}
