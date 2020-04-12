using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject GameOverMenu;
    public GameObject GameCanvas; 
    public GameObject RankCanvas;

    public DataStorage dataStorage; 
 
   public void Play()
    { 
        StartMenu.SetActive(false);
        GameCanvas.SetActive(true);
    }

    public void Rank()
    {
        RankCanvas.SetActive(true); 
    }

    public void GameOver(int score)
    {
        dataStorage.SetHighScore(score); 

        GameOverMenu.SetActive(true);
        GameCanvas.SetActive(false);
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
