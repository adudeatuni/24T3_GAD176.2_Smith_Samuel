using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tracker", menuName = "Tracker/Create New Tracker")]
public class Tracker : ScriptableObject
{
    public string trackerName;
    public int trackerID;
    public int chancesLeft;
    public bool playerSpotted;
}
