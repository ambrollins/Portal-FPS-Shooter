using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SlowLidRemove : MonoBehaviour
{

    public Transform target;
    public Transform home;
    public float speed;
    public bool isOpenLid ;
    
    bool m_ToggleChange;
    public GameObject doorIsOpenedPanel;


    private void Start()
    {
    }

    private void Update()
    {
        LidFunctions();
    }

    public void LidFunctions()
    {
        if (isOpenLid == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (isOpenLid == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, home.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision lid)
    {
        if (lid.collider.CompareTag("LidOpenDetector"))
        {
            Debug.Log("LidOpenDetector");
        }
    }
    
}