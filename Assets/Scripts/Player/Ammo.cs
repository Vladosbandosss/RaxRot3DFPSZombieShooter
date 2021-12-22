using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AmmoType
{
   BULLETS,
   SHELLS,
   ROCKETS
}
public class Ammo : MonoBehaviour
{
   [System.Serializable]
   private class  AmmoSlot
   {
      public AmmoType ammoType;
      public int ammoAmount;
   }
   
   [SerializeField] private AmmoSlot[] amoslots;

   public int GetCurrentAmmo(AmmoType type)
   {
      return GetAmmoSlot(type).ammoAmount;
   }

   public void ReduceCurrentAmmo(AmmoType type)
   {
      GetAmmoSlot(type).ammoAmount--;
   }

   public void IncreaceCurrentAmmo(AmmoType type,int ammoAmount)
   {
      GetAmmoSlot(type).ammoAmount += ammoAmount;
   }
   private AmmoSlot GetAmmoSlot(AmmoType type)
   {
      foreach ( AmmoSlot slot in amoslots)
      {
         if (slot.ammoType == type)
         {
            return slot;
         }
      }

      return null;
   }
}
