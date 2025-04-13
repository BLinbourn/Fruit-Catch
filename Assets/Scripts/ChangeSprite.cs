using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] Sprite[] charcterSprites;
    [SerializeField] GameObject boxSprite;
    [SerializeField] GameObject truck;

    private Sprite newCharacter;

    private List<GameObject> boxes = new List<GameObject>();

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
            SpawnCrate();
        }
        else
        {
            newCharacter = charcterSprites[0];
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = newCharacter;
    }

    public void SpawnCrate()
    {
        float vectorX = 0;
        float vectorY = 0;

        if (ScoreManager.instance.scoreBoxCounter >= 100 && ScoreManager.instance.scoreBoxCounter < 200)
        {
            vectorX = -10f;
            vectorY = 1.3f;
        } else if (ScoreManager.instance.scoreBoxCounter >= 200 && ScoreManager.instance.scoreBoxCounter < 300)
        {
            vectorX = -9f;
            vectorY = 1.3f;
        } else if (ScoreManager.instance.scoreBoxCounter >= 300 && ScoreManager.instance.scoreBoxCounter < 400)
        {
            vectorX = -8f;
            vectorY = 1.3f;
        } else if (ScoreManager.instance.scoreBoxCounter >= 400 && ScoreManager.instance.scoreBoxCounter < 500)
        {
            vectorX = -9.5f;
            vectorY = 2.2f;
        } else if (ScoreManager.instance.scoreBoxCounter >= 500 && ScoreManager.instance.scoreBoxCounter < 600)
        {
            vectorX = -8.5f;
            vectorY = 2.2f;
        } else if (ScoreManager.instance.scoreBoxCounter >= 600)
        {
            vectorX = -9f;
            vectorY = 3.1f;
            ScoreManager.instance.scoreBoxCounter = 0;
            StartCoroutine(TruckMovement());
        }

        boxes.Add(Instantiate(boxSprite, new Vector3(vectorX, vectorY, 0f), Quaternion.identity));

    }

    IEnumerator TruckMovement()
    {
        float time = 5f;
        float timeElapsed = 0f;

        Vector2 onScreen = new Vector2(-10f, 3f);
        Vector2 offScreen = new Vector2(-16f, 3f);

        while (timeElapsed < time)
        {
            truck.transform.position = Vector2.Lerp(offScreen, onScreen, (timeElapsed / time));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        timeElapsed = 0;

        yield return new WaitForSeconds(5);

        foreach (var box in boxes)
        {
            Destroy(box);
        }

        yield return new WaitForSeconds(5);

        while (timeElapsed < time)
        {
            truck.transform.position = Vector2.Lerp(onScreen, offScreen, (timeElapsed / time));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }
}
