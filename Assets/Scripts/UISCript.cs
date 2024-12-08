using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StealthFramework.Events;
public class UISCript : MonoBehaviour
{
    public Text text;
   [SerializeField] private Tracker tracker;
    // Start is called before the first frame update
    void Update()
    {
       text.text = ("Player has " + tracker.chancesLeft + " Chances left!");
    }


}
