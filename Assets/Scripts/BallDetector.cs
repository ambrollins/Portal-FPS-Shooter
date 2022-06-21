using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    private bool _ballIsConverted;
    private MyBall _myBall;
    public GameObject ball;
    private SlowLidRemove _slowLidRemove;

    private void Start()
    {
        _slowLidRemove = FindObjectOfType<SlowLidRemove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("win");
            _slowLidRemove.isOpenLid = false;
        }
    }
}