using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPositionFlag : MonoBehaviour
{

    [SerializeField] private AudioSource endFlagAudioEffect;
    private bool pushFinishedFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !pushFinishedFlag)
        {
            pushFinishedFlag = true;
            endFlagAudioEffect.Play();
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Select Level");
    }
}
