using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSelectLevel : MonoBehaviour
{
    public void IsReturnClick()
    {
        SceneManager.LoadScene("Start");
    }
    public void IsChoseLevel()
    {
        SceneManager.LoadScene("Select Level");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }
}
