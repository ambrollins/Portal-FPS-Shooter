using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MyBall : MonoBehaviour
{
    public Transform whereToPlace;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _dropDown;
    private EnemyAI _enemyAI;
    private bool _gotIt;
    public GameObject gotItPanel;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        LiftAndDisablePhysicalProperties();
    }

    private void OnMouseUp()
    {
        DropAndEnablePhysicalProperties();
    }
    void LiftAndDisablePhysicalProperties()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        this.transform.position = whereToPlace.position;
        this.transform.parent = GameObject.Find("PlaceHere").transform;
        StartCoroutine(CheckIfPlayerParent());
    }

    void DropAndEnablePhysicalProperties()
    {
        this.transform.parent = null; 
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<SphereCollider>().enabled = true;
        StartCoroutine(PlayDoingSound());
    }

    IEnumerator  PlayDoingSound()
    {
        yield return new WaitForSeconds(.6f);
        //Debug.Log("boing");
        DropSound();
    }

    void DropSound()
    {
        _audioSource.clip = _dropDown;
        _audioSource.Play();
    }

    IEnumerator CheckIfPlayerParent()
    {
        if (this.transform.parent == GameObject.Find("PlaceHere").transform)
        {
            gotItPanel.SetActive(true);
            yield return new WaitForSeconds(1f);
            gotItPanel.SetActive(false);
        }
    }
}
