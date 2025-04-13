using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public Text FinalScoreText;
    public Text ExtraPointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Fruit Caught: " + score.ToString();
        FinalScoreText.text = "Final Score: " + ScoreManager.instance.finalScore.ToString();
        ExtraPointsText.text = "Extra Points: " + ScoreManager.instance.extraScore.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("First Game");
        ScoreManager.score = 0;
        ObjectBehaviour.instance.gameOver = false;
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
