using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseDetection : MonoBehaviour
{
    private SlowLidRemove _slowLidRemove;
    [SerializeField] private AudioClip DoorClose;

    private AudioSource m_AudioSource;
    //public GameObject doorIsOpenedPanel;

    private void Start()
    {
        m_AudioSource = FindObjectOfType<AudioSource>();
        _slowLidRemove = FindObjectOfType<SlowLidRemove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.CompareTag("Lid") && _slowLidRemove.isOpenLid == false)
        {
            PlayCloseAudio();
            Debug.Log("closeAudio");
        }
    }

    private void PlayCloseAudio()
    {
        m_AudioSource.clip =  DoorClose;
        m_AudioSource.Play();
    }
    
    
}