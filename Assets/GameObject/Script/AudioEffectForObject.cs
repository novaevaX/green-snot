using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectForObject : MonoBehaviour
{
    [SerializeField] AudioSource audioEffect;
    private void OnBecameVisible()
    {
        audioEffect.Play();
    }

    private void OnBecameInvisible()
    {
        audioEffect.Stop();
    }
}
