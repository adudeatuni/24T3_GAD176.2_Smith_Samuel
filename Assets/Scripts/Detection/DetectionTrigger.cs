using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StealthFramework.Unity.Detection;

namespace StealthFramework.Detection.Visual
{
public class DetectionTrigger : MonoBehaviour
{
    [SerializeField] float distanceBetween;
    [SerializeField] private Collider detectedObject;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)  // gets a referemce to the collider that entered the trigger, stores it as "other"
    {
        detectedObject = other;
        DetectInTrigger();
    }

    protected void DetectInTrigger()
    {
        
        Debug.Log("" + detectedObject.gameObject.name + " has entered a detection trigger!");

        Vector3 directionBetween = (transform.root.position - detectedObject.transform.position).normalized;   // Gets distance and direction between the parent object and the thing in the cone of vision
        distanceBetween = Vector3.Distance(transform.root.position, detectedObject.transform.position);

        Ray lineOfSightRay = new Ray (detectedObject.transform.position,(directionBetween * distanceBetween)); // Creates ray and sets variables for it
        Debug.DrawRay(detectedObject.transform.position,(directionBetween * distanceBetween));     

        if (Physics.Raycast(lineOfSightRay, out RaycastHit lineOfSight, distanceBetween))   // checks ray for if it has hit something, and stores it as "lineOfSightRay"
        {
            Debug.Log("" + lineOfSight.transform.name + " was hit!");
            if (lineOfSight.transform.root == transform.root)
            {
                Debug.Log("Detector sees a rigidbody!");
            }
            else
            {
                Debug.Log("Detector does not see a rigid body!");
            }

        }

    }
}
}
