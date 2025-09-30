using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text startButtonText;
    public TMP_Text quitButtonText;

    public Button startButton;
    public Button quitButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("First Game");
        ScoreManager.score = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartButtonHooverOn()
    {
        startButtonText.color = Color.white;
        startButton.image.color = new Color(0.18f, 0.22f, 0.29f);
    }

    public void StartButtonHooverOff()
    {
        startButtonText.color = Color.black;
        startButton.image.color = new Color(0.72f, 0.97f, 0.97f);
    }

    public void ExitButtonHooverOn()
    {
        quitButtonText.color = Color.white;
        quitButton.image.color = new Color(0.18f, 0.22f, 0.29f);
    }

    public void ExitButtonHooverOff()
    {
        quitButtonText.color = Color.black;
        quitButton.image.color = new Color(0.72f, 0.97f, 0.97f);
    }
}
