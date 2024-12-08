using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StealthFramework.Detection;
public class DetectionTurnToFace : DetectionTrigger
{
    private Quaternion lookToFace;
    [SerializeField] private float rotateSpeed;
    void OnTriggerStay(Collider other)
    {
        if (other.transform.root != transform.root) // checks if the object in the trigger does not have the same parent object (prevents detection of other objects attatched to the same parent.)
        {
            detectedObject = other;
            DetectInTrigger();
            if (somethingInTrigger == true)
            {
                lookToFace = Quaternion.LookRotation(detectedObject.transform.position - transform.root.position);
                transform.root.rotation = Quaternion.RotateTowards(transform.root.rotation, lookToFace, rotateSpeed * Time.deltaTime);
            }
        }
    }

}
