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
    [SerializeField] private AudioClip DoorClose;

    [SerializeField] private GameObject gameWonPanel;

    private AudioSource m_AudioSource;
    private void Start()
    {
        _slowLidRemove = FindObjectOfType<SlowLidRemove>();
        m_AudioSource = FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("win");
            GameWon();
            _slowLidRemove.isOpenLid = false;
            PlayCloseAudio();
        }
    }
    private void PlayCloseAudio()
    {
        m_AudioSource.clip =  DoorClose;
        m_AudioSource.Play();
    }

    void GameWon()
    {
        gameWonPanel.SetActive(true);
    }
}