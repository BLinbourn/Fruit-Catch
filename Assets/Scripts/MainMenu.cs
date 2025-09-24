using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text startButton;
    public TMP_Text quitButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("First Game");
        ScoreManager.score = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        startButton.color = Color.red;
        quitButton.color = Color.blue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        startButton.color = Color.blue;
        quitButton.color = Color.red;
    }
}
