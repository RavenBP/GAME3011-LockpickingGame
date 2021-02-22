using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockpickMinigame : MonoBehaviour
{

    [Header("References")]
    [SerializeField]
    GameObject lockpick;

    [SerializeField]
    GameObject pin;

    [SerializeField]
    Text rakesText;
    [SerializeField]
    Text lockDifficultyText;
    [SerializeField]
    Text playerSkillText;

    [Header("Settings")]
    [Tooltip("Amount of time the player has to pick the lock.")]
    [SerializeField]
    float time;

    [Range(0.01f, 0.9f)]
    [Tooltip("Affects the thickness of the pin.")]
    [SerializeField]
    float lockDifficulty = 0.5f;

    [Range(0.1f, 10.0f)]
    [Tooltip("Affects the thickness of the lockpick.")]
    [SerializeField]
    float playerSkill = 0.1f;

    public static int rakesNeeded = 10;
    public static int timesRaked = 0;

    public static float timeRemaining;

    private bool noTime;

    private AudioSource audioSource;

    void Start()
    {
        timeRemaining = time;
        noTime = false;
        timesRaked = 0;

        audioSource = GetComponent<AudioSource>();

        // Set Text
        lockDifficultyText.text = "Lock Difficulty: " + ((int) (lockDifficulty * 100)).ToString();
        playerSkillText.text = "Player Skill: " + ((int) (playerSkill * 100)).ToString();

        // Set Lockpick/Pin Scales
        pin.transform.localScale = new Vector3(pin.transform.localScale.x - lockDifficulty, pin.transform.localScale.y, pin.transform.localScale.z);
        lockpick.transform.localScale = new Vector3(lockpick.transform.localScale.x + playerSkill, lockpick.transform.localScale.y, lockpick.transform.localScale.z);

        // Begin Timer
        InvokeRepeating("UpdateLockpickMinigame", 0.0f, 1.0f);
    }

    private void Update()
    {
        // Close Lockpick Minigame
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Lockpick Minigame Canceled");
            Destroy(gameObject);
        }

        rakesText.text = "Rakes Needed: " + (rakesNeeded - timesRaked).ToString();

        if (timesRaked >= rakesNeeded)
        {
            CancelInvoke();

            // Allow access to whatever the lock was attached to (door, chest, etc.) here.
            audioSource.Play();

            Debug.Log("Lock Unlocked!");
            Destroy(gameObject);
        }
    }

    void UpdateLockpickMinigame()
    {
        if (noTime == false)
        {
            DecrementTimeRemaining(1.0f);
        }
        else // No Time Remaining
        {
            Debug.Log("No Time Remaining! - GAME OVER");

            CancelInvoke();

            Destroy(gameObject);
        }
    }

    void DecrementTimeRemaining(float seconds)
    {
        timeRemaining -= seconds;

        if (timeRemaining <= 0.0f)
        {
            noTime = true;
        }
    }
}