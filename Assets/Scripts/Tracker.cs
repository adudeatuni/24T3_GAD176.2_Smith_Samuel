using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StealthFramework.Detection;



namespace StealthFramework.Events
{
[CreateAssetMenu(fileName = "New Tracker", menuName = "Tracker/Create New Tracker")]

public class Tracker : ScriptableObject
{
    public string trackerName;
    public int trackerID;
    public int chancesLeft;
    public bool playerSpotted;

    void OnEnable()
    {
        chancesLeft = 3;
        DetectionTrigger.onPlayerDetected += PlayerHasBeenSpotted;
    }

    void OnDisable()
    {
        DetectionTrigger.onPlayerDetected -= PlayerHasBeenSpotted;
    }

    void PlayerHasBeenSpotted()
    {
        chancesLeft --;
        if (chancesLeft <= 0)
        {
            Debug.Log("PLAYER SPOTTED TO MANY TIMES!");
        }
    }
}
}
