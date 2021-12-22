using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
   [SerializeField] private int currentWeapon;

   private void Start()
   {
      SetWeaponActive();
   }

   private void Update()
   {
      ProcessKeyInput();
   }

   private void ProcessKeyInput()
   {
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
         currentWeapon = 0;
      }
      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
         currentWeapon = 1;
      }
      if (Input.GetKeyDown(KeyCode.Alpha3))
      {
         currentWeapon = 2;
      }
      
      SetWeaponActive();
   }

   private void SetWeaponActive()
   {
      int weaponIndex = 0;

      foreach (Transform weapon in transform)
      {
         if (weaponIndex == currentWeapon)
         {
            weapon.gameObject.SetActive(true);
         }
         else
         {
            weapon.gameObject.SetActive(false);
         }

         weaponIndex++;
      }
   }
}
