using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDetection : MonoBehaviour
{
    private SlowLidRemove _slowLidRemove;
    [SerializeField] private AudioClip DoorOpen;
    public GameObject doorCloseDetector;
    private AudioSource m_AudioSource;
    public GameObject doorIsOpenedPanel;

    private void Start()
    {
        m_AudioSource = FindObjectOfType<AudioSource>();
        _slowLidRemove = FindObjectOfType<SlowLidRemove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lid"))
        {
            PlayOpenAudio();
            StartCoroutine( DoorIsOpenedPanel());
        }
    }

    private void PlayOpenAudio()
    {
        m_AudioSource.clip =  DoorOpen;
        m_AudioSource.Play();
    }
    
    IEnumerator DoorIsOpenedPanel()
    {
        doorIsOpenedPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        doorIsOpenedPanel.SetActive(false);
        GetComponent<BoxCollider>().isTrigger = false;
        doorCloseDetector.gameObject.SetActive(true);
    }
}
