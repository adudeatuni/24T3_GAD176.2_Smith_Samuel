using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StealthFramework.Events;


namespace StealthFramework.Detection
{
public class DetectionTrigger : MonoBehaviour
{
    [SerializeField] float distanceBetween;
    [SerializeField] protected Collider detectedObject;
    [SerializeField] protected Vector3 directionBetween;

    protected Ray lineOfSightRay;
    [SerializeField] protected bool somethingInTrigger;
    [SerializeField] protected bool hasLineOfSight;

    [SerializeField] protected Tracker stealthTracker;

    public delegate void PlayerDetected();
    public static event PlayerDetected onPlayerDetected;

    


    protected void OnEnable()
    {
        DetectionTrigger.onPlayerDetected += onPlayerDetected;
    }
    protected void DetectInTrigger()
    {
    
        Debug.Log("" + detectedObject.gameObject.name + " is inside a detection trigger!");

        directionBetween = (transform.root.position - detectedObject.transform.position).normalized;   // Gets distance and direction between the parent object and the thing in the cone of vision
        distanceBetween = Vector3.Distance(transform.root.position, detectedObject.transform.position);

        lineOfSightRay = new Ray (detectedObject.transform.position,(directionBetween * distanceBetween)); // Creates ray and sets variables for it
        Debug.DrawRay(detectedObject.transform.position,(directionBetween * distanceBetween));

        if (detectedObject != null)
            {somethingInTrigger = true;}
        else if (detectedObject == null)
            {somethingInTrigger = false;}
    }

    protected void CheckLineOfSight()
        {
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

    
    protected void OnTriggerExit(Collider other)
    {
        if(other = detectedObject)
        {
            somethingInTrigger = false;
        }
        
    }

    protected void PlayerBeenSpotted()
    {
            

            detectedObject.transform.GetComponent<Rigidbody>().position = new Vector3(0, 0, 0);
            if (onPlayerDetected != null)
            {
                if (somethingInTrigger == true)
                {
                    onPlayerDetected();
                    somethingInTrigger = false;
                }
                
            }
            
            
    }
        


}
}

