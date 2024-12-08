using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StealthFramework.Detection;

public class DetectionPeriodic : DetectionTrigger
{
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        detectedObject = other;
        DetectInTrigger();
        if (somethingInTrigger == true)
        {
            Debug.Log("something found in the trigger of: " + transform.root.name);
            CheckLineOfSight();
        }
    }
    
}

