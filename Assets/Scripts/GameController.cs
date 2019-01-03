using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Game Manager controls every functions in the game
/// </summary>
public class GameController : MonoBehaviour
{
    //Text fields
    [SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private Text highscoreText;
    [SerializeField]
    private Text streakText;
    [SerializeField]
    private Text timerText;

    //Streak multiplier
    private int multiplier = 1;

    //Scores
    private int currentScore;
    private int highScore;

    //timer countdown
    int timer = 60;
    
    //GameOver Panel
    public GameObject EndGameCanvas;

    //Intialization of everything including HighScore using PlayerPrefs
    void Start()
    {
        Time.timeScale = 1.0f;
        currentScoreText.text = "Score: 0";
        streakText.text = "Streak   " + multiplier.ToString() + "x!";

        highScore = PlayerPrefs.GetInt("HighScore");
        highscoreText.text= "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();

        timerText.text = "Time left: " + timer.ToString();

        EndGameCanvas.SetActive(false);

        StartCoroutine(UpdateTimer());
    }

    //TimerCountdown
    IEnumerator UpdateTimer()
    {
        yield return new WaitForSeconds(1f);
        timer--;
        timerText.text = "Time left: " + timer.ToString();
        CheckForEnd();
        if (timer != 0)
        {
            StartCoroutine(UpdateTimer());
        }
        else
        {
            EndGame();
        }
        yield return null;
    }
    
    //Called when Game over, updates time Scale to 0
    private void EndGame()
    {
        
        EndGameCanvas.SetActive(true);
        currentScore += timer;
        EndGameCanvas.GetComponentInChildren<Text>().text = "Congratulations you gained " + currentScore.ToString() + " points! \n Bonus Points:" +timer.ToString();
        Time.timeScale = 0.0f;
    }

    //Called by player during collision
    public void UpdateScore(int points)
    {
        points = points * multiplier;
        currentScore += points;

        currentScoreText.text = "Score: " + currentScore.ToString();

        if (currentScore>highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore",highScore);
            highscoreText.text = "HighScore:"+ highScore.ToString();
                
        }
    }

    //Called by player during collision
    public void UpdateStreak(string previousColor, string currentColor)
    {

        if(previousColor==currentColor)
        {
            multiplier++;
        }
        else
        {
            multiplier = 1;
        }

        streakText.text = "Streak  " + multiplier.ToString() + "x!";

        CheckForEnd();
    }

    //Checks for zero prefabs
    public void CheckForEnd()
    {
        if(GameObject.FindGameObjectsWithTag("Prefab").Length==0)
        {
           
            EndGame();
        }
    }
}
