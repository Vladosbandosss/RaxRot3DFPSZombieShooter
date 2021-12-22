using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealPlayer : MonoBehaviour
{
    private int heal;
    private int minHeal = 10;
    private int maxHeal = 50;

    private bool canHeal;

    private Light _healPlatformLight;
    
    private void Start()
    {
        heal = Random.Range(minHeal, maxHeal);
        canHeal = true;
        _healPlatformLight = GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&canHeal)
        {
           other.GetComponent<PlayerHealth>().HealPlayer(heal);
           canHeal = false;
           _healPlatformLight.intensity = 0;
        }
    }
}
