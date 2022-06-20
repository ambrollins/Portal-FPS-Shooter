using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    private bool _ballIsConverted;
    private PickUp _pickUp;
    public GameObject ball;
    private void Start()
    {
        GetComponent<GameObject>().CompareTag("Ball");
    }
    
    public bool Approximately(Vector3 ball_bc, Vector3 ball_ac, float allowedDifference)
    {
        var dx = ball_bc.x - ball_ac.x;
        if (Mathf.Abs(dx) > allowedDifference)
            return false;
 
        var dy = ball_bc.y - ball_ac.y;
        if (Mathf.Abs(dy) > allowedDifference)
            return false;
 
        var dz = ball_bc.z - ball_ac.z;
 
        return Mathf.Abs(dz) >= allowedDifference;
    }
    
}
