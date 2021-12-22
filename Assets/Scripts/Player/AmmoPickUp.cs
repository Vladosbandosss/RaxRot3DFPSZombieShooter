using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] private int ammoAmmount = 5;
    [SerializeField] private AmmoType ammoType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.PickUpBullets();
            FindObjectOfType<Ammo>().IncreaceCurrentAmmo(ammoType,ammoAmmount);
            Destroy(gameObject);
        }
    }
}
