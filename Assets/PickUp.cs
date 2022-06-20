using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform whereToPlace;

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
    }
}
