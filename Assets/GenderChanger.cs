using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider genderPlane)
    {
        //Destroy(genderPlane.gameObject,1f);
        genderPlane.gameObject.transform.localScale = new Vector3(1, 1, 1);
        genderPlane.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
}
