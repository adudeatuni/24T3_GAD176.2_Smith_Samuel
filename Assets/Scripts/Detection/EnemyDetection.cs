using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemy is like detecting and stuff now!");
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20, Color.yellow); 
        
        
    }
}
