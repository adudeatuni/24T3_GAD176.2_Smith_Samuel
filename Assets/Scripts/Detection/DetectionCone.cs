using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StealthFramework.Unity.Detection;

namespace StealthFramework.Detection.Visual
{
public class DetectionCone : MonoBehaviour
{
    public float distanceBetween;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerStay(Collider other)  // gets a referemce to the collider that entered the trigger, stores it as "other"
    {
        Debug.Log("" + other.gameObject.name + " has entered the detection cone!");

        Vector3 directionBetween = (transform.root.position - other.transform.position).normalized;   // Gets distance and direction between the parent object and the thing in the cone of vision
        distanceBetween = Vector3.Distance(transform.root.position, other.transform.position);

        Ray lineOfSightRay = new Ray (other.transform.position,(directionBetween * distanceBetween)); // Creates ray and sets variables for it
        Debug.DrawRay(other.transform.position,(directionBetween * distanceBetween));     

        if (Physics.Raycast(lineOfSightRay, out RaycastHit lineOfSight, distanceBetween))   // checks ray for if it has hit something, and stores it as "lineOfSightRay"
        {
            Debug.Log("" + lineOfSight.transform.name + " was hit!");
            if (lineOfSight.transform.root == transform.root)
            {
                Debug.Log("Detector sees something!");
            }
            else
            {
                Debug.Log("Detector sees nothing important!");
            }

        }
    }
}
}
