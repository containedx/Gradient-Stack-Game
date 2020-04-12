using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject GameOverMenu; 
   public void Play()
    { 
        StartMenu.SetActive(false); 
    }

    public void Rank()
    {

    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
    }

    public void Ouit()
    {
        Application.Quit(); 
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stack");
    }
}
