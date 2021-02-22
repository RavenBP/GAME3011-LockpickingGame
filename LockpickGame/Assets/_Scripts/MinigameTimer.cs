using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameTimer : MonoBehaviour
{
    //[SerializeField]
    //Text timerText;

    private Text timerText;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    private void Update()
    {
        timerText.text = "Time Remaining: " + LockpickMinigame.timeRemaining.ToString();
    }
}