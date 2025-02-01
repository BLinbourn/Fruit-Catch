using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] Sprite[] charcterSprites;
    private Sprite newCharacter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        System.Console.WriteLine(ScoreManager.score);

        if (ScoreManager.score >= 50)
        {
            newCharacter = charcterSprites[1];
        }
        else
        {
            newCharacter = charcterSprites[0];
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = newCharacter;
    }
}
