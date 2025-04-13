using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public static ChangeSprite instance;

    [SerializeField] Sprite[] charcterSprites;
    
    private Sprite newCharacter;
    private void Awake()
    {
        instance = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (ScoreManager.instance.scoreCounter >= 50 && ScoreManager.instance.scoreCounter <= 100)
        {
            newCharacter = charcterSprites[1];
        }
        else if (ScoreManager.instance.scoreCounter >= 100)
        {
            newCharacter = charcterSprites[0];
            ScoreManager.instance.scoreCounter = 0;
            ScoreManager.instance.extraScore += 5;
            BoxController.instance.SpawnCrate();
        }
        else
        {
            newCharacter = charcterSprites[0];
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = newCharacter;
    }
}
