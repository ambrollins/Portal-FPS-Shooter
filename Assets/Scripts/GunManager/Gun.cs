using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
public class Gun : MonoBehaviour
{
   public float damage = 50f;
   public float shootRange;
   public Camera fpsCam;


   
   [Header("trigger")] 
   public ParticleSystem muzzleFlash;

   private void Start()
   {
      fpsCam = Camera.main;
   }

   private void Update()
   {
      if (Input.GetButtonDown("Fire1"))
      {
         Shoot();
      }
   }

   private  void Shoot()
   {
      muzzleFlash.Play();
      RaycastHit hit;
      if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, shootRange));
      {
         Debug.Log(hit.transform.name);
         Target target = hit.transform.GetComponent<Target>();
         if (target != null)
         {
            target.TakeDamage(damage);
         }
      }
   }
}
