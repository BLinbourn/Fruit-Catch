using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] ObjectBehaviour objectBehaviour;

    float playerSpeed = 150f;
    float inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        objectBehaviour.SpawnObject();
    }

    // Update is called once per frame
    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        if(inputHorizontal != 0)
        {
            rb.AddForce(new Vector2(inputHorizontal * playerSpeed, 0));
        }
    }
}
