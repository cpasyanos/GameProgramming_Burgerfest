using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : UnitySingleton<ScoreManager> {
    [Tooltip("The starting time in seconds for the game timer.")]
    public int MAX_TIME_VALUE =  100;

    [Tooltip("The text that will show the game timer.")]
    public Text timerText;
    private int timer;
    public int Timer
    {
        get { return timer; }
        private set
        {
            timer = value;
            if (timerText != null)
            {
                timerText.text = "Time: " + timer.ToString();
            }
        }
    }

    [Tooltip("The text that will show the game score.")]
    public Text scoreText;
    private int score;
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

    private void Reset()
    {
        StopAllCoroutines();
        Score = 0;
        Timer = MAX_TIME_VALUE;
    }

	void Start () {
        Reset();
        StartCoroutine(TimerCoroutine());
	}

    private IEnumerator TimerCoroutine()
    {
        while(Timer > 0)
        {
            Timer--;
            yield return new WaitForSeconds(1);
        }
    }

    public void LosePoints(int pointsToLose)
    {
        Score -= pointsToLose;
    }

    public void GainPoints(int pointsToGain)
    {
        Score += pointsToGain;
    }
}
