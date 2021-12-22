using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] private float _health = 100f;

   private HealthSlider _healthSlider;
   
   private void Start()
   {
       _healthSlider = GameObject.Find("HealthSlider").GetComponent<HealthSlider>();
   }

   public void TakeDamage(int damage)
    {
        _health -= damage;
        _healthSlider.GetComponent<HealthSlider>().DecreaseHealthSlider(damage);
        if (_health <= 0)
        {
           GetComponent<DeathHandler>().HandleDeath();
        }
        
        AudioManager.instance.HeartPlayer();
    }

   public void HealPlayer(int heal)
   {
       _health += heal;
       _healthSlider.GetComponent<HealthSlider>().IncreaseHealthSlider(heal);

       if (_health > 100)
       {
           _health = 100;
       }
   }
}
