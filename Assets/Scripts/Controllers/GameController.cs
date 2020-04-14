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

    public bool gameactive; 

    public DataStorage dataStorage;

    public void Start()
    {
        gameactive = false; 
    }

    public void Play()
    { 
        StartMenu.SetActive(false);
        GameCanvas.SetActive(true);

        activategame(); 
    }

    IEnumerator activategame()
    {
        yield return new WaitForSeconds(1);

        gameactive = true; 
    }

    public void Rank()
    {
        RankCanvas.SetActive(true); 
    }

    public void GameOver(int score)
    {
        dataStorage.SetHighScore(score);
        gameactive = false; 

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

    public void BackToMenu()
    {
        StartMenu.SetActive(true);
        RankCanvas.SetActive(false);
    }
}
