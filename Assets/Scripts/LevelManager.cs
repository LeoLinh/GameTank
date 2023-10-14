using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int currentScore = 0;
    public int highScore;
    public Text score;
    public Text yourScore;
    public Text highScoreText;
    public GameObject gameOverPanel;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gameOverPanel.SetActive(false);
    }
    private void Update()
    {
        score.text = "Score: "+ currentScore.ToString();
        yourScore.text ="Your "+ score.text;
        if(currentScore > PlayerPrefs.GetInt("Highscore"))
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("Highscore", highScore);
        }

        highScoreText.text = "High score: " + PlayerPrefs.GetInt("Highscore");
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }


    public void GetHighScore()
    {

    }
    public void Retry()
    {
        SceneManager.LoadScene("MakeGame");
        Time.timeScale = 1.0f;
    }

}
