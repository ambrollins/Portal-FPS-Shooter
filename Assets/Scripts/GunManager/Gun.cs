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
   
   public float fireRate= 15f;
   public float nectTimeToFire = 25f;
   
   //[SerializeField] private GameObject decalPrefab;
   [SerializeField] private GameObject impactEffect;
   [SerializeField] private AudioSource fireSound;
   [SerializeField] private float impactForce = 25f;

   
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
         //SpawnDecal(hit);
         Debug.Log(hit.transform.name);
         Target target = hit.transform.GetComponent<Target>();
         if (target != null)
         {
            target.TakeDamage(damage);
         }
         fireSound.Play();
         if (hit.rigidbody != null)
         {
            hit.rigidbody.AddForce(-hit.normal*impactForce);
         }

         GameObject gameObjectHitEffect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
         Destroy(gameObjectHitEffect,1.2f);
         
      }
   }
   // private void SpawnDecal(RaycastHit hit)
   // {
   //    GameObject decal = Instantiate(decalPrefab, hit.point + (hit.normal * .01f), Quaternion.identity);
   //    decal.transform.forward = hit.normal;
   //    Destroy(decal, 5f);
   // }
}
