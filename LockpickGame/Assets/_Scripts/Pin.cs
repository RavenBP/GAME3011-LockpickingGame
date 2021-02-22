using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    float speed = 400.0f;
    [SerializeField]
    float offset = 200.0f;
    [SerializeField]
    bool randomizeValues = false;

    private Vector3 startingPosition;

    private bool canMoveRight;

    private void Start()
    {
        startingPosition = transform.position;
        canMoveRight = true;

        if (randomizeValues)
        {
            speed = Random.Range(200.0f, 800.0f);
            offset = Random.Range(50.0f, 300.0f);
        }
    }

    private void Update()
    {
        if (canMoveRight)
        {
            if (transform.position.x >= startingPosition.x + offset)
            {
                canMoveRight = false;
            }

            transform.position += new Vector3(1.0f, 0, 0) * speed * Time.deltaTime;
        }
        else //if (canMoveRight == false)
        {
            if (transform.position.x <= startingPosition.x - offset)
            {
                canMoveRight = true;
            }

            transform.position += new Vector3(-1.0f, 0, 0) * speed * Time.deltaTime;
        }
    }
}
