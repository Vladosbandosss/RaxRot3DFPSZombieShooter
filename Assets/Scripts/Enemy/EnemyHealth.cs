using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   [SerializeField] private float hitPoints = 100;

   private bool isDead = false;

   public bool IsDead()
   {
       return isDead;
   }
   
   public void TakeDamage(float damage)
   {
      GetComponent<EnemyAI>().OnDamageTaken();
      hitPoints -= damage;
      if (hitPoints <= 0f)
      {
          Die();
      } 
      
   }

   private void Die()
   {
       if (isDead)
       {
           return;
       }
       
       isDead = true;
       GetComponent<Animator>().SetTrigger("die");
   }
}