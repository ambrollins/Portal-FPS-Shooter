using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform whereToPlace;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _dropDown;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<SphereCollider>().enabled = false;
        this.transform.position = whereToPlace.position;
        this.transform.parent = GameObject.Find("PlaceHere").transform;
    }
    private void OnMouseUp()
    {
        this.transform.parent = null; 
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<SphereCollider>().enabled = true;
        StartCoroutine(PlayDoingSound());
    }

    IEnumerator  PlayDoingSound()
    {
        yield return new WaitForSeconds(.6f);
        Debug.Log("boing");
        DropSound();
    }

    void DropSound()
    {
        _audioSource.clip = _dropDown;
        _audioSource.Play();
    }
   
}
