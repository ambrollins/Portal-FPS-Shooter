using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderChanger : MonoBehaviour
{
    private SlowLidRemove _slowLidRemove;
    [SerializeField] private Material black;

    private void Start()
    {
        _slowLidRemove = FindObjectOfType<SlowLidRemove>();
    }


    private void OnTriggerEnter(Collider ball)
    {
        //Destroy(genderPlane.gameObject,1f);
        ball.gameObject.transform.localScale = new Vector3(1, 1, 1);
        ball.gameObject.GetComponent<Renderer>().material = black;
        _slowLidRemove.isOpenLid = true;
    }
   
}