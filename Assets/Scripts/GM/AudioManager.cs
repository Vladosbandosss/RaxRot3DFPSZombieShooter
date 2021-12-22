using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _pickUpSound;
    [SerializeField] private AudioClip _heartPlayer;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PickUpBullets()
    {
        _audioSource.PlayOneShot(_pickUpSound);
    }

    public void HeartPlayer()
    {
        _audioSource.PlayOneShot(_heartPlayer);
    }
}
