using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text ScoreText;
    public Text HighscoreText;

    public static int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        ScoreText.text = "Score: " + score.ToString();
        HighscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void AddScore(string fruit)
    {
        switch (fruit)
        {
            case "Apple":
                score += 1;
                break;
            case "Banana":
                score += 2;
                break;
            case "Cherry":
                score += 3;
                break;
            case "Strawberry":
                score += 4;
                break;
            case "Pineapple":
                score += 5;
                break;
            case "Melon":
                score += 6;
                break;
        }

        ScoreText.text = "Score: " + score.ToString();

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
