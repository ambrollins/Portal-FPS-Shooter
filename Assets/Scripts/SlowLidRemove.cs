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
    [SerializeField] private AudioClip DoorOpen;
    [SerializeField] private AudioClip DoorClose;
    
    private AudioSource m_AudioSource;
    bool m_ToggleChange;
    private bool m_Play;
    

    private void Start()
    {
         m_AudioSource = GetComponent<AudioSource>();
         m_Play = true;
    }

    private void Update()
    {
        OpenLid();
        if (isOpenLid == true && m_ToggleChange == true)
        {
            m_AudioSource.clip = DoorOpen;
            m_AudioSource.Play();
            m_ToggleChange = false;
        }
        if (isOpenLid == false && m_ToggleChange == true)
        {
            m_AudioSource.clip = DoorClose;
            m_AudioSource.Play();
            m_ToggleChange = false;
        }
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

    void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        m_Play = GUI.Toggle(new Rect(10, 10, 100, 30), m_Play, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there was just a change in the toggle state
            m_ToggleChange = true;
        }
    }
}
