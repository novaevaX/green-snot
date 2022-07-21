using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedTrapTrigger : MonoBehaviour
{
    private bool enterBox = false;
    [SerializeField] float timeCreateTrap = 1.5f;
    [SerializeField] GameObject invisibleTraps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enterBox)
        {
            enterBox = true;
            Invoke("CreateTrap", timeCreateTrap);
        }
        
    }

    private void CreateTrap()
    {
        Instantiate(invisibleTraps, transform.position, transform.rotation);
    }
}
