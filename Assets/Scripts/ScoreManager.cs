using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : UnitySingleton<ScoreManager>
{
    public GameObject TimeLoseGameobject;
    public GameObject gameOverScreen;

    [Tooltip("The starting time in seconds for the game timer.")]
    public int MAX_TIME_VALUE = 300;
    [Tooltip("The time lost each time you drop something on the floor.")]
    public int TIME_LOST_AMOUNT = 5;

    [Tooltip("The text that will show the game timer.")]
    public Text timerText;
    private int timer;
    public int Timer
    {
        get { return timer; }
        private set
        {
            timer = value;
            if (timer < 0)
            {
                timer = 0;
            }
            if (timerText != null)
            {
                timerText.text = "Time: " + timer.ToString();
            }
            if (timer == 0)
            {
                GameOver();
            }
        }
    }

    [Tooltip("The text that will show the game score.")]
    public Text scoreText;
    private int score;
    public Text finalText;
    public int Score
    {
        get
        {
            return score;
        }
        private set
        {
            score = value;
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score.ToString();
            }
        }
    }
    private void GameOver()
    {
        //lol idk
        displayScore();
        Cursor.lockState = CursorLockMode.None;
        gameOverScreen.SetActive(true);
    }

    private void Reset()
    {
        StopAllCoroutines();
        Score = 0;
        Timer = MAX_TIME_VALUE;
    }

    void Start()
    {
        Reset();
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (Timer > 0)
        {
            Timer--;
            yield return new WaitForSeconds(1);
        }
    }

    public void LoseTime()
    {
        Timer -= TIME_LOST_AMOUNT;
        // stop then start the timer effect
        TimeLoseGameobject.SetActive(false);
        TimeLoseGameobject.SetActive(true);
    }

    public void GainPoints(int pointsToGain)
    {
        Score += pointsToGain;
    }

    public void displayScore()
    {
        finalText.text = "Your final score was " + score.ToString();
    }
}
