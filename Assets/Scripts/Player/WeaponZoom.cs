using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
   [SerializeField] private Camera FPSCamera;
   [SerializeField] private float zoomedOutFOV = 60f;
   [SerializeField] private float zoomedInFOV = 25f;
   
   private bool zoomedInToggle = false;

 
   [SerializeField] private float zoomedOutSensivity = 2f;
   [SerializeField] private float zoomedInSensivity = 0.7f;
   
   private void Update()
   {
      if (Input.GetMouseButtonDown(1))
      {
         ChangeFOV(zoomedInToggle);
         zoomedInToggle = !zoomedInToggle;
      }
   }

   private void ChangeFOV(bool fov)
   {
      if (fov)
      {
         FPSCamera.fieldOfView = zoomedOutFOV;
         MouseLook.XSensitivity = zoomedOutSensivity;
         MouseLook.YSensitivity =zoomedOutSensivity;
      }
      else
      {
         FPSCamera.fieldOfView = zoomedInFOV;
         MouseLook.XSensitivity = zoomedInSensivity;
         MouseLook.YSensitivity =zoomedInSensivity;
      }
   }
}
