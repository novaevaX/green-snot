using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconAction : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public void IsReturnClick()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void IsHomeClick()
    {
        pausePanel.SetActive(false);
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
    }

    public void IsResumeClick()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }


}
