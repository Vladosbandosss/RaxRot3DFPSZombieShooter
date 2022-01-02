using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Camera FPSCamera;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float damage = 30f;

    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffect;

    [SerializeField] private Ammo ammoSlot;
    [SerializeField] private AmmoType AmmoType;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _soundShoot;

    [SerializeField] private Text ammoText;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        DisplayAmmo();
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(AmmoType);
        ammoText.text = currentAmmo.ToString();
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(AmmoType) > 0)
        {
            _audioSource.PlayOneShot(_soundShoot);
            ammoSlot.ReduceCurrentAmmo(AmmoType);
            PlayMuzzleFlash();
            RaycastHit hit;
            
            if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, _range))
            {
                CreateHitImpact(hit);
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if (target == null)
                {
                    return;
                }
                target.TakeDamage(damage);
            }
            else
            {
                return;
            }
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void CreateHitImpact(RaycastHit raycastHit)
    {
        Instantiate(hitEffect, raycastHit.point, Quaternion.identity);
    }

}
