using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private GameOverScreen GameOverScreen;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        ScoreManager.instance.AddExtraScore(); 
        GameOverScreen.Setup(ScoreManager.score);
    }
}
