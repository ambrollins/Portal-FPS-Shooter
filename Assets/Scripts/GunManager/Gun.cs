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
   
   [SerializeField] private GameObject decalPrefab;


   
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
         SpawnDecal(hit);
         Debug.Log(hit.transform.name);
         Target target = hit.transform.GetComponent<Target>();
         if (target != null)
         {
            target.TakeDamage(damage);
         }
      }
   }
   private void SpawnDecal(RaycastHit hit)
   {
      GameObject decal = Instantiate(decalPrefab, hit.point + (hit.normal * .01f), Quaternion.identity);
      decal.transform.forward = hit.normal;
      Destroy(decal, 5f);
   }
}
