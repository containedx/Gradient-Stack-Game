using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class DataStorage : MonoBehaviour
{

    public int highScore;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        PlayerPrefs.SetInt(Keys.HIGHSCORE, highScore);
        Debug.Log( highScore ); 
    }


    [ContextMenu("Load")]
    public void Load()
    {
        highScore = PlayerPrefs.GetInt(Keys.HIGHSCORE);
        highScoreText.text = highScore.ToString(); 
    }

    public void SetHighScore(int score)
    {
        if (highScore < score)
            highScore = score;
        Save(); 
    }
}

public static class Keys
{
    public const string HIGHSCORE = "HighScore"; 
}