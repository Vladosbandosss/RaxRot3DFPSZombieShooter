using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] private int ammoAmmount = 5;
    [SerializeField] private AmmoType ammoType;

    private string PLAYERTAG = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYERTAG)
        {
            AudioManager.instance.PickUpBullets();
            FindObjectOfType<Ammo>().IncreaceCurrentAmmo(ammoType,ammoAmmount);
            Destroy(gameObject);
        }
    }
}
