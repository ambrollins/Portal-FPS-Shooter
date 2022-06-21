using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowLidRemove : MonoBehaviour
{
    
    public Transform target;
    public Transform home;
    public float speed;
    public bool isOpenLid = false;
    

    private void Update()
    {
        OpenLid();
    }

    public void OpenLid()
    {
        if (isOpenLid == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        }
        else if (isOpenLid == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, home.position, speed*Time.deltaTime);
        }
    }
}
