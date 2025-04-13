using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public static BoxController instance;

    [SerializeField] GameObject boxSprite;

    [HideInInspector] public List<GameObject> boxes = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public void SpawnCrate()
    {
        float vectorX = 0;
        float vectorY = 0;

        if (ScoreManager.instance.scoreBoxCounter >= 100 && ScoreManager.instance.scoreBoxCounter < 200)
        {
            vectorX = -10f;
            vectorY = 1.3f;
        }
        else if (ScoreManager.instance.scoreBoxCounter >= 200 && ScoreManager.instance.scoreBoxCounter < 300)
        {
            vectorX = -9f;
            vectorY = 1.3f;
        }
        else if (ScoreManager.instance.scoreBoxCounter >= 300 && ScoreManager.instance.scoreBoxCounter < 400)
        {
            vectorX = -8f;
            vectorY = 1.3f;
        }
        else if (ScoreManager.instance.scoreBoxCounter >= 400 && ScoreManager.instance.scoreBoxCounter < 500)
        {
            vectorX = -9.5f;
            vectorY = 2.2f;
        }
        else if (ScoreManager.instance.scoreBoxCounter >= 500 && ScoreManager.instance.scoreBoxCounter < 600)
        {
            vectorX = -8.5f;
            vectorY = 2.2f;
        }
        else if (ScoreManager.instance.scoreBoxCounter >= 600)
        {
            vectorX = -9f;
            vectorY = 3.1f;
            ScoreManager.instance.scoreBoxCounter = 0;
            StartCoroutine(TruckController.instance.TruckMovement());
        }

        boxes.Add(Instantiate(boxSprite, new Vector3(vectorX, vectorY, 0f), Quaternion.identity));
    }
}
