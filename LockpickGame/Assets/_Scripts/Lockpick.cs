using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockpick : MonoBehaviour
{
    bool canRake;
    bool movingRight;
    bool movingLeft;

    [SerializeField]
    float lockpickSpeed = 5.0f;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        canRake = false;
        movingRight = false;
        movingLeft = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LockpickInput();

        if (canRake)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Debug.Log("Player raked");
                audioSource.Play();

                LockpickMinigame.timesRaked++;
            }
        }
    }

    void LockpickInput()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            movingRight = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movingLeft = false;
        }

        if (movingRight == true)
        {
            transform.position += new Vector3(1.0f, 0.0f, 0.0f) * lockpickSpeed * Time.deltaTime;
        }

        if (movingLeft == true)
        {
            transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * lockpickSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pin"))
        {
            //Debug.Log("Touching Pin");
            canRake = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pin"))
        {
            //Debug.Log("No longer touching Pin");
            canRake = false;
        }
    }
}
