using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    [SerializeField] private AudioSource playerDieAudioEffect;
    // Start is called before the first frame update
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        playerDieAudioEffect.Play();
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("triggerDeath");
    }

    private void RestarLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
