using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public static TruckController instance;

    [SerializeField] Sprite[] truckSprites;

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator TruckMovement()
    {
        float time = 5f;
        float timeElapsed = 0f;

        Vector2 onScreen = new Vector2(-10f, 2.5f);
        Vector2 offScreen = new Vector2(-16f, 2.5f);

        gameObject.GetComponent<SpriteRenderer>().sprite = truckSprites[0];

        while (timeElapsed < time)
        {
            transform.position = Vector2.Lerp(offScreen, onScreen, (timeElapsed / time));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        timeElapsed = 0;

        yield return new WaitForSeconds(5);

        foreach (var box in BoxController.instance.boxes)
        {
            Destroy(box);
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = truckSprites[1];

        yield return new WaitForSeconds(5);

        while (timeElapsed < time)
        {
            transform.position = Vector2.Lerp(onScreen, offScreen, (timeElapsed / time));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
