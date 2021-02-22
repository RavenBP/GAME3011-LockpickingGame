using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameObject lockpickMinigamePrefab;

    [SerializeField]
    GameObject initializeButton;

    private GameObject lockpickMinigameObject;

    // Initialize Lockpick Minigame
    public void StartButton()
    {
        lockpickMinigameObject = Instantiate(lockpickMinigamePrefab, this.transform);
    }
}
