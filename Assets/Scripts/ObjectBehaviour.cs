using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabList = new List<GameObject>();

    public static ObjectBehaviour instance;

    public bool gameOver = false;
    public static string fruit = "";

    private void Awake()
    {
        instance = this;
    }

    public void SpawnObject()
    {
        int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count);

        Instantiate(prefabList[prefabIndex], new Vector3(Random.Range(-11f, 11f), 16f, 0f), Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !gameOver)
        {
            SpawnObject();
            Destroy(gameObject);
            fruit = gameObject.tag;

            ScoreManager.instance.AddScore(fruit);

        } 
        else if (collision.gameObject.tag == "Ground")
        {
            gameOver = true;
            GameController.instance.GameOver();
        }
    }

}
